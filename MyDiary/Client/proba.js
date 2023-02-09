import { Api } from "./api.js"
console.log("e bre")
var api = new Api();

var kor={
    "id": "63e43570e9307e86b36dd280",
    "name": "Probica",
    "lastName": "Bubica",
    "email": "Proba",
    "username": "Proba",
    "password": "Proba",
    "diary": "Proba",
    "birthday": "Proba"
  }


var ch= await api.getAllPages()


console.log(ch)