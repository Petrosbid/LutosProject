let slideIndex = 1;

const SlideshowContainer=document.querySelector(".slideshow-container")
const DotContiner=document.querySelector(".dot--continer")


let ImageSliader=
[
{id:1,src:"./testimage/Background.jpg"},
{id:2,src:"./testimage/peakpx.jpg"},
{id:3,src:""},
{id:4,src:"./testimage/korean-earrings-2-min.jpg"},

]
function AddSlide(){//اگر بر روی دکمه کلیک کردیم این تابع اجرا شود
    ImageSliader.forEach(function(item) {
        
        SlideshowContainer.insertAdjacentHTML("beforeend","<div class='mySlides fade'>  <img  class='continer__image--slider' alt='This is image' src="+item.src+" > </div>")
        DotContiner.insertAdjacentHTML("beforeend","<span class='dot' onclick='currentSlide("+item.id+")'></span> ")
    });
    SlideshowContainer.insertAdjacentHTML("beforeend","<a class='prev' onclick='plusSlides(-1)'>❮</a><a class='next' onclick='plusSlides(1)'>❯</a>")
}
AddSlide();


showSlides(slideIndex);
// setInterval(ShowSlides,2000);

setInterval(ShowSlides, 4000);//برای وض کردن زمانی
function plusSlides(n) {
  showSlides(slideIndex += n);
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {

  let i;
  let slides = document.getElementsByClassName("mySlides");
  let dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1}    
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";  
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";  
  dots[slideIndex-1].className += " active";
}
function ShowSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";  
    }
    slideIndex++;
    if (slideIndex > slides.length) {slideIndex = 1}    
    for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex-1].style.display = "block";  
    dots[slideIndex-1].className += " active";
     // Change image every 2 seconds
}