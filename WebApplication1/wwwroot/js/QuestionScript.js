let rotate=document.querySelectorAll(".animation")
let answerText=document.querySelectorAll(".answer")
let text=document.querySelectorAll(".answer__text")

function showcase(i){
    if(rotate[i].classList.contains("rotate"))
    {
        rotate[i].classList.remove("rotate")
        rotate[i].classList.add("rotate-back")



        answerText[i].classList.remove("openAnswer")
        answerText[i].classList.add("closeAnswer")
        text[i].classList.remove("showText")
        text[i].classList.add("hideText")
        setTimeout(function(){
            answerText[i].style.display="none"
        },400)

    }
    else
    {
        rotate[i].classList.remove("rotate-back")

        rotate[i].classList.add("rotate")


        answerText[i].style.display="block"
        answerText[i].classList.add("openAnswer")
        answerText[i].classList.remove("closeAnswer")
        text[i].classList.add("showText")
        text[i].classList.remove("hideText")

    }
 
  
   
    


   
}
