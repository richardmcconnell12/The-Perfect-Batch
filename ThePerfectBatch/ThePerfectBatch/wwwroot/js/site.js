// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var formInput = document.getElementsByClassName("form-row");



document.getElementById("add-ingredient").addEventListener("click", function () {
    var elements = document.querySelectorAll(".ingredient-item");
    var count = elements.length;

    var newIngredientLabel = document.createElement("label");
    var newQuantityLabel = document.createElement("label");

    var newIngredientInput = document.createElement("input");
    var newQuantityInput = document.createElement("input");

        newIngredientLabel.setAttribute("class", "control-label");
        newIngredientLabel.setAttribute("id", "name-label");
        newIngredientLabel.setAttribute("for", "Ingredient_" + count + "__Name");
        newQuantityLabel.setAttribute("class", "control-label");
        newQuantityLabel.setAttribute("id", "quantity-label");
        newQuantityLabel.setAttribute("for", "Ingredient_" + count + "__Quantity");


        newIngredientLabel.innerHTML = "Name";
        newQuantityLabel.innerHTML = "Quantity";

        newIngredientInput.setAttribute("class", "form-control");
        newIngredientInput.setAttribute("id", "name-input");
        newQuantityInput.setAttribute("class", "form-control");
        newQuantityInput.setAttribute("id", "quantity-input");

        newIngredientInput.setAttribute("name", "Ingredients[" + count + "].Name");
        newQuantityInput.setAttribute("name", "Ingredients[" + count + "].Quantity");

        newIngredientInput.setAttribute("type", "text");
        newQuantityInput.setAttribute("type", "text");

        var formInputDiv = document.querySelector(".form-row");
        console.log(formInputDiv)

        formInputDiv.append(newIngredientLabel);
        formInputDiv.append(newIngredientInput);
        formInputDiv.append(newQuantityLabel);
        formInputDiv.append(newQuantityInput);
   


})