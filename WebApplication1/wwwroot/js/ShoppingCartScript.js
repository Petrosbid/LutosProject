let cartItem=document.querySelectorAll(".cart-item")
let cartTotalPriceElem=document.querySelector(".cart-total-price")
let inpQuantiti=document.querySelectorAll("input")
let removeBtn=document.querySelectorAll(".btn-danger")
let productPrice=document.querySelectorAll(".cart-item-price")
console.log(cartItem[0].childNodes[9]); 
cartItem.forEach(function(item) {

 
    item.childNodes[9].addEventListener("change",function(event){
   
        calcTotalPrice()
    })
item.childNodes[11].addEventListener("click",function(event){
    event.target.parentElement.remove()
     cartItem=document.querySelectorAll(".cart-item")
      inpQuantiti=document.querySelectorAll("input")
    productPrice=document.querySelectorAll(".cart-item-price")
    calcTotalPrice()
})
    
})
calcTotalPrice()



function calcTotalPrice () {
    let totalPriceValue = 0

    let j=0
    cartItem.forEach(function (product) {
        totalPriceValue +=Number(inpQuantiti[j].value)*Number(productPrice[j].innerHTML)
        j++
    })

    cartTotalPriceElem.innerHTML = totalPriceValue
}
