const showPass=document.querySelector(".show-pass")
const passInp=document.querySelector(".pass")
const hidePass=document.querySelector(".hide-pass")
const email=document.querySelector(".user--email")
let emailRegEx=/.+@.+.com/
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
/////////////////////////////////////////////////
let userMessage=document.querySelector(".error--handler__username")
let emailMessage=document.querySelector(".error--handler__useremail")
let btn=document.querySelector("button")
let userInp=document.querySelector(".user--name")
btn.addEventListener("click",function(){

    if(userInp.value=="poori")
    {
        userInp.value=""
        userMessage.classList.add("hide--message")
        setTimeout(function(){
            
            userMessage.classList.remove("hide--message")
            },3000)
    }
    if(!emailRegEx.test(email.value))
    {
            emailMessage.classList.add("hide--message")
            setTimeout(function(){
                emailMessage.classList.remove("hide--message")
                },3000)
        
    }
})