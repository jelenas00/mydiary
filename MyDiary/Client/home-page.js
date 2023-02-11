import { Api } from "./api.js";

var api= new Api();

var kor=JSON.parse(sessionStorage.getItem("logKorisnik"))
// var dn= await api.getDiaryById(kor.diary);
document.getElementsByName("nameandlast").forEach(el=>{
    el.innerHTML=kor.name+' '+kor.lastName
})

document.getElementById("towrite").onclick=async (ev)=>{
    console.log("ej")
    var pass= document.getElementById("yourPasswordw").value
    console.log(pass, kor.id)
     var ch= await api.unlockDiary(kor.diary,pass)
     console.log(ch)
    console.log(ch)
    if(ch==false){
        alert("Pogresna loznika!")
    }
    else{
        window.location.href="write-diary.html"
    }
}

document.getElementById("toread").onclick=async (ev)=>{
    console.log("ej")
    var pass= document.getElementById("yourPassword").value
    console.log(pass, kor.diary)
    var ch= await api.unlockDiary(kor.diary,pass)
    if(ch==false){
        alert("Pogresna loznika!")
    }
    else{
        window.location.href="read-diary.html"
    }
}