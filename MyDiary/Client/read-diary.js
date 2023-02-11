import { Api } from "./api.js";

var api= new Api();

var kor=JSON.parse(sessionStorage.getItem("logKorisnik"))
var dn=await api.getDiaryById(kor.diary);
document.getElementsByName("nameandlast").forEach(el=>{
    el.innerHTML=kor.name+' '+kor.lastName
})
document.getElementById("prikazi").onclick=(ev)=>{
    var date= document.getElementById("datum").value
    if(String(date).length==0)
    {
        alert("Odaberite datum!")
    }
    else{
        show(date);
    }
    
}
async function show(date){
    document.getElementById("prikazstrana").innerHTML=``
    console.log(date)
    var today= new Date(date)
    console.log(today.toLocaleDateString("es-CL"))
    var yesterday= new Date(today)
    var tommorow= new Date(today)
    yesterday.setDate(yesterday.getDate() - 1)
    tommorow.setDate(tommorow.getDate() + 1)
    var pages= await api.getPagesByDate(today.toLocaleDateString("es-CL"))
    if(pages.length==0)
    {
        document.getElementById("read-card").style.display = "none"
        alert("Nema dostupnih stranica za taj datum! :)")
        
    }
    else{
        console.log(pages)
        document.getElementById("read-card").style.display = "block"
        pages.forEach(el=>{
            document.getElementById("prikazstrana").innerHTML+=`
                    <label for="readWeather" class="col-sm-2 col-form-label"> <i class="bi bi-cloud-sun-fill"></i> Weather:</label>
                    <div class="col-sm-12">
                        <textarea class="form-control" name="readWeather" style="height: 70px; resize: none;" readonly>${el.weather}</textarea>
                    </div>
                    <label for="readWeather" class="col-sm-2 col-form-label"> <i class="bi bi-cloud-sun-fill"></i> Feeling:</label>
                    <div class="col-sm-12">
                        <textarea class="form-control" name="readWeather" style="height: 70px; resize: none;" readonly>${el.feeling}</textarea>
                    </div>
                    <label for="readText" class="col-sm-2 col-form-label"> <i class="bi bi-book-half"></i> Read:</label>
                    <div class="col-sm-12">
                        <textarea class="form-control" name="readText" style="height: 200px" readonly>${el.pagecontent}</textarea>
                    </div>
        `
    })
    }
    console.log(document.getElementById("previousday"))
    document.getElementById("previousday").onclick=(ev)=>show(yesterday)
    document.getElementById("nextday").onclick=(ev)=>show(tommorow)
}
