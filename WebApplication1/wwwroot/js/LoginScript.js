const hidePass=document.querySelector(".hide-pass")
const showPass=document.querySelector(".show-pass")
const passInp=document.querySelector(".pass")
const userInp=document.querySelector(".user--name")

hidePass.addEventListener("click",function(){
    hidePass.style.display="none"
    showPass.style.display="block"   
    passInp.setAttribute("type","password")
})
showPass.addEventListener("click",function(){
    showPass.style.display="none"
    hidePass.style.display="block"
    passInp.setAttribute("type","text")
})
///////////////////////////Data Base
let userMessage=document.querySelector(".error--handler__username")
let succeseeMessage=document.querySelector(".error--handler__success")
const btn=document.querySelector(".card button")

btn.addEventListener("click",function(){

    // userMessage.classList.remove("hide--message")
    // passMessage.classList.remove("hide--message")
    // succeseeMessage.classList.remove("hide--message")

    if(userInp.value=="poori" && passInp.value=="1234")
    {
        
        //succeseeMessage.style.display="inline-block"
        succeseeMessage.classList.add("hide--message")
        setTimeout(function(){
            
            succeseeMessage.classList.remove("hide--message")
            },3000)
    }
    
    if(userInp.value!="poori")
    {
        //userMessage.style.display="inline-block"
        userMessage.classList.add("hide--message")
        setTimeout(function(){
        
            userMessage.classList.remove("hide--message")
        },3000)
    }
    
    if(passInp.value!="1234")
    {
        
        //passMessage.style.display="inline-block"
        passMessage.classList.add("hide--message")
        setTimeout(function(){
            passMessage.classList.remove("hide--message")
    
            },3000)
    }

    userInp.value=""
    passInp.value=""
})

