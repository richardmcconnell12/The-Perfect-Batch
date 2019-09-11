// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var formInput = document.getElementsByClassName("form-row");

document.getElementById("add-ingredient").addEventListener("click", function () {
    console.log("click");
    var elements = document.getElementById("ingredient-input");
    var count = elements.length;

    var newIngredientLabel = document.createElement("label");
    var newQuantityLabel = document.createElement("label");

    var newIngredientInput = document.createElement("input");
    var newQuantityInput = document.createElement("input");

    newIngredientLabel.setAttribute("class", "control-label");
    newIngredientLabel.setAttribute("id", "name-input");
    newQuantityLabel.setAttribute("class", "control-label");
    newQuantityLabel.setAttribute("id", "quantity-input");


    newIngredientLabel.innerHTML = "Name";
    newQuantityLabel.innerHTML = "Quantity";

    newIngredientInput.setAttribute("id", "Ingredient_" + count + " __Name");
    newQuantityInput.setAttribute("id", "Quantity_" + count + "__Quantity");

    newIngredientInput.setAttribute("class", "Ingredient");
    newQuantityInput.setAttribute("class", "Quantity");


    newIngredientInput.setAttribute("name", "Ingredient[" + count + "].Name");
    newQuantityInput.setAttribute("name", "Quantity[" + count + "].Quantity");

    newIngredientInput.setAttribute("type", "text");
    newQuantityInput.setAttribute("type", "text");

    var formInputDiv = document.querySelector(".form-row");
    console.log(formInputDiv)

    formInputDiv.append(newIngredientLabel);
    formInputDiv.append(newIngredientInput);
    //formInputDiv.getElementsByTagName("form")[0].append(formInputDiv.createElement("br"))
    formInputDiv.append(newQuantityLabel);
    formInputDiv.append(newQuantityInput);
    //document.getElementsByTagName("form")[0].append(document.createElement("br"))


})