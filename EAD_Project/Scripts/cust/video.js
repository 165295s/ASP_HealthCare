/**
*  HTML5 Webcam Barcode Reader with Dynamsoft Barcode Reader SDK.
*  Support PC.
*/
var videoElement = document.querySelector('video');
var canvas = document.getElementById('pcCanvas');
var videoSelect = document.querySelector('select#videoSource');
var videoOption = document.getElementById('videoOption');
var buttonGo = document.getElementById('go');
var barcode_result = document.getElementById('dbr');
var PatientNRIClbl = $('#lblPatientNRIC');

var isPaused = false;
var videoWidth = 640, videoHeight = 480;
var isPC = true;

var seconds = 120;
var countDownId;

// check devices
function browserRedirect() {
    var deviceType;
    var sUserAgent = navigator.userAgent.toLowerCase();
    var bIsIpad = sUserAgent.match(/ipad/i) == "ipad";
    var bIsIphoneOs = sUserAgent.match(/iphone os/i) == "iphone os";
    var bIsMidp = sUserAgent.match(/midp/i) == "midp";
    var bIsUc7 = sUserAgent.match(/rv:1.2.3.4/i) == "rv:1.2.3.4";
    var bIsUc = sUserAgent.match(/ucweb/i) == "ucweb";
    var bIsAndroid = sUserAgent.match(/android/i) == "android";
    var bIsCE = sUserAgent.match(/windows ce/i) == "windows ce";
    var bIsWM = sUserAgent.match(/windows mobile/i) == "windows mobile";
    if (bIsIpad || bIsIphoneOs || bIsMidp || bIsUc7 || bIsUc || bIsAndroid || bIsCE || bIsWM) {
        deviceType = 'phone';
    } else {
        deviceType = 'pc';
    }
    return deviceType;
}

if (browserRedirect() == 'pc') {
    isPC = true;
} else {
    isPC = false;
}

// initialize camera infos for Chrome
function initCameraSource(sourceInfos) {
    for (var i = 0; i < sourceInfos.length; i++) {
        var sourceInfo = sourceInfos[i];
        var option = document.createElement('option');
        option.value = sourceInfo.id;
        if (sourceInfo.kind === 'video') {
            option.text = sourceInfo.label || "Camera " + (videoSelect.length + 1);
            videoSelect.appendChild(option);
        } else {
            console.log("Source info: " + sourceInfo);
        }
    }
    toggleCamera();
}

function successCallback(stream) {
    window.stream = stream;
    videoElement.src = window.URL.createObjectURL(stream);
    videoElement.play();
}

function errorCallback(error) {
    console.log("Error: " + error);
}

function startCamera(constraints) {
    if (navigator.getUserMedia) {
        navigator.getUserMedia(constraints, successCallback, errorCallback);
    } else {
        console.log("getUserMedia not supported");
    }
}

function toggleCamera() {
    var videoSource = videoSelect.value;
    var constraints = {
        video: {
            optional: [{
                sourceId: videoSource
            }]
        }
    };

    startCamera(constraints);
}

function countDown(){
    buttonGo.textContent = 'Reading ' + '(' + seconds + ' sec)';
    if (seconds > 0) seconds--;
    else resetButtonGo();
}

// add button event

buttonGo.onclick = function () {

    if (isPC) {
        canvas.style.display = 'none';
    } else {
        return;
    }

    seconds = 120;
    countDown();
    countDownId = setInterval(countDown, 1000);

    isPaused = false;
    scanBarcode();
    buttonGo.disabled = true;

    // clear barcode result
    barcode_result.innerHTML = "";
    document.getElementById("image").style.display = "none";
    
};



$('video').css('display', 'block');
$('#divErrInfo').css('display', 'none');

// query supported Web browsers
if (navigator.getUserMedia || navigator.mozGetUserMedia) {
    navigator.getUserMedia = navigator.getUserMedia || navigator.mozGetUserMedia;
    startCamera({
        video: {
             //mandatory: {
             //  maxWidth: 640,
             //  maxHeight: 480
             //}
        }
    });
} else if (navigator.webkitGetUserMedia) {
    videoOption.style.display = 'none';
    navigator.getUserMedia = navigator.webkitGetUserMedia;
    MediaStreamTrack.getSources(initCameraSource);
    videoSelect.onchange = toggleCamera;
} else {
    $('video').css('display', 'none');
    $('#divErrInfo').css('display', 'table-cell');
    $('#divErrInfo').html("Current browser doesn't support webcam." + ' Please try other <a target="_blank" class="browsersInfo" href="http://caniuse.com/#search=getUserMedia">browsers</a>.');
}

// scan barcode
function scanBarcode() {
    if (isPaused) {
        return;
    }

    var context = null,
    width = 0,
    height = 0,
    dbrCanvas = null;

    if (isPC) {
		var ctx = canvas.getContext('2d');
        context = ctx;
        width = videoWidth;
        height = videoHeight;
        dbrCanvas = canvas;
    } else {
        return;
    }

    context.drawImage(videoElement, 0, 0, width, height);

    // convert canvas to base64
    var base64 = dbrCanvas.toDataURL('image/png', 1.0);
    var data = base64.replace(/^data:image\/(png|jpeg|jpg);base64,/, "");

    Dynamsoft.BarcodeReaderDemo.ReadFromImage("WebcamBarcodeReader.ashx", data, getBarcodeFormat(), 1, uploadComplete, uploadProgress, uploadFailed, uploadCanceled);
}

function uploadComplete(evt) {
    /* This event is raised when the server send back a response */
    if(isPaused)
    {
        return;
    }

    var result = JSON.parse(evt.target.responseText);

    $.ajax({
        type: "POST",
        url: "VisitorManagementService.asmx/checkVisitorCnt",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify({ PatientNRIC: PatientNRIClbl.text() }),
        dataType: "json",
        async: true,
        success: function (data) {
            if (data.d < 4) {

                if (result.barcodes != null && result.barcodes.length > 0) {
                    resetButtonGo();
                    var strMsg = "Total barcode(s) found: " + result.barcodes.length + ".<br/>";
                    var strMsg2 = "";
                    for (var idx = 0; idx < result.barcodes.length; ++idx) {
                        strMsg = strMsg + "Barcode " + (idx + 1) + ":<br/>";
                        strMsg = strMsg + "Type: <b>" + result.barcodes[idx].formatString + "</b><br/>";
                        strMsg = strMsg + "NRIC: <b>" + convertTextForHTML(result.barcodes[idx].displayValue) + "</b><br/>";
                        strMsg2 = result.barcodes[idx].displayValue;
                    }
                    barcode_result.innerHTML = strMsg;
                    $.ajax({
                        type: "POST",
                        url: "VisitorManagementService.asmx/checkVisitor",
                        contentType: "application/json;charset=utf-8",
                        data: JSON.stringify({ VisitorNRIC: strMsg2 }),
                        dataType: "json",
                        async: true,
                        success: function (data) {
                            if (data.d > 0) {
                                $.ajax({
                                    type: "POST",
                                    url: "VisitorManagementService.asmx/InsertPatientVisitDetails",
                                    contentType: "application/json;charset=utf-8",
                                    data: JSON.stringify({ VisitorNRIC: strMsg2, PatientNRIC: PatientNRIClbl.text() }),
                                    dataType: "json",
                                    async: true,
                                    success: function (data) {
                                        alert("Please proceed on to visit");
                                    },
                                    error: function () {
                                        alert("Error");
                                    }
                                });
                            } else {
                                alert("Please scan again or register yourself if you have not")
                            }
                        },
                        error: function () {
                            return false;
                        }
                    });
                    

                }
                else {
                    setTimeout(scanBarcode, 200);
                }
                

            } else {
                alert("There are currently 4 visitors visiting this patient");
                resetButtonGo();
            }
        },
        error: function () {
            return false;
        }
    });

    
}

function uploadFailed(evt) {
    alert("There was an error attempting to upload the file.");
}

function uploadCanceled(evt) {
    alert("The upload has been canceled by the user or the browser dropped the connection.");
}

function uploadProgress(evt) {
}

function ClickCheckBox(obj) {
    if (getBarcodeFormat() == 0) {
        resetButtonGo();
    }
}

function getBarcodeFormat() {
    var vType = 0;
    var barcodeType = document.getElementsByName("BarcodeType");
    for (i = 0; i < barcodeType.length; i++) {
        if (barcodeType[i].checked == true)
            vType = vType | (barcodeType[i].value * 1);
    }
    return vType;
}

function resetButtonGo() {
    isPaused = true;
    buttonGo.disabled = false;
    buttonGo.textContent = 'Read Barcode';
    clearInterval(countDownId);
}

function convertTextForHTML(str) {
    str = str.replace(/</g, '&lt;');
    str = str.replace(/>/g, '&gt;');
    str = ['<pre style="display:inline;border:none;font-size:inherit;font-family: inherit;background:transparent;white-space:pre-wrap;">', str, '</pre>'].join('');
    if ((str.indexOf('\n') & str.indexOf('\r')) != -1) {
        str = '<br>' + str;
    }
    return str;
}
