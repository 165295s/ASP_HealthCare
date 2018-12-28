using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class FoodCustomisation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            MainDropDownList.ClearSelection();
            MeatDropDownList.ClearSelection();
            FruitDropDownList.ClearSelection();
            VegetableDropDownList.ClearSelection();
            SideDropDownList.ClearSelection();
            DrinkDropDownList.ClearSelection();
            RequestBox.Text = "";
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            FoodDAO foodOrdering = new FoodDAO();
            string myStringVariable = "Food Order Sucessfully Submitted";
            if (NRICBox.Text == "" && NameBox.Text == "" ){
                ErrorLabelNRIC.Text = "Please Enter your NRIC";
            }
            else if(FoodMealList.SelectedValue == "")
            {
                ErrorLabelMeal.Text = "Please Select your Meal";
                ErrorLabelNRIC.Text = "";
            }
            else if(MainDropDownList.SelectedIndex == 0 || MeatDropDownList.SelectedIndex == 0 || FruitDropDownList.SelectedIndex == 0 || VegetableDropDownList.SelectedIndex == 0 || SideDropDownList.SelectedIndex == 0 || DrinkDropDownList.SelectedIndex == 0)
            {
                ErrorLabelFood.Text = "Please Choose your Food Choices";
                ErrorLabelMeal.Text = "";
            }
            else if (foodOrdering.checkMeal(NRICBox.Text, FoodMealList.SelectedItem.Text) == true)
            {
                ErrorLabelRepeatedMeal.Text = "You already placed an order for that meal";
    }
            else{

                String Main = MainDropDownList.SelectedValue;
                String Meat = MeatDropDownList.SelectedValue;
                String Fruit = FruitDropDownList.SelectedValue;
                String Vegetable = VegetableDropDownList.SelectedValue;
                String Side = SideDropDownList.SelectedValue;
                String Drink = DrinkDropDownList.SelectedValue;
                String Request = RequestBox.Text;
                String Meal = FoodMealList.SelectedItem.Text;
                String NRIC = NRICBox.Text;
                String Name = NameBox.Text;
                int WardNo = Convert.ToInt32(WardNoBox.Text);

                FoodDAO foodDao = new FoodDAO();

                foodDao.insertData(Main, Meat, Fruit, Vegetable, Side, Drink, Request, Meal, NRIC, Name, WardNo);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                Session["NRIC"] = NRICBox.Text;

               
                

                
            }

        }

        protected void EnterButton_Click(object sender, EventArgs e)
        {
            FoodPatientInfoDAO foodpatientinfodao = new FoodPatientInfoDAO();
            List<FoodPatientInfoObject> listInfo = new List<FoodPatientInfoObject>();
           
           

            String nricbox = NRICBox.Text;
            listInfo = foodpatientinfodao.getCurrentTdRte(nricbox);


            for (int i = 0; i < listInfo.Count; i++) {
                WardNoBox.Text =listInfo[i].WardNo.ToString();
                ConditionBox.Text =listInfo[i].Condition;
                DietBox.Text = listInfo[i].Diet;
                NameBox.Text = listInfo[i].PatientName;

            }

           
        }
    }
}