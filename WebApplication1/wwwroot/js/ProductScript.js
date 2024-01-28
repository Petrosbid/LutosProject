let like=document.querySelector(".like--icon")

    like.addEventListener("click",function(){
    
        if(like.classList.contains("red--icon"))
        {
            like.classList.remove("red--icon")
        }
        else
        {
            like.classList.add("red--icon")
        }
    })