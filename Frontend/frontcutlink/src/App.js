import React, { useState, useEffect} from 'react';
import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHearder} from 'reactstrap';

function App() {

  const BASE_URL = "https://localhost:44337/api/CutLinks";
  const[data, setDAta]=useState([]);
  const[registroSeleccionado, setRegistroSeleccionado]=useState({
    ciRegistros:'',
    urlOriginal:'',
    fechaIngreso:'',
    estado:''
  })
  
  

  const handlechange=e=>{
    const {name,value}=e.target;
    setRegistroSeleccionado({
      ...registroSeleccionado,
      [name]: value
    });
    console.log(registroSeleccionado);
  }

  const peticionPost=async()=>{
    delete registroSeleccionado.ciRegistros;
    await axios.post(BASE_URL,registroSeleccionado)
    .then(response=>{
      setDAta(data.concat(response.data));
      
    }).catch(error=>{
      console.log(error);
      alert(error);
    })
  }

  return (
    <div className="App">
      <br></br>
      <h1 className ="swal2-title">Proyecto Shorten link</h1>
      <br></br>
      <div className="card card-success">
        <div className="card-body">
          <div className="row justify-content-center">
            <div class="col-sm-4">
              <div class="form-group">
                <label>Original Link: </label>
                <input name="urlOriginal" type="text" className="form-control" onChange={handlechange}/>
              </div>
            </div>
            
          </div>
          <div className ="row justify-content-center">
            <div class="col-sm-4">
              <div class="form-group">
                <input type="button" name="btnCutLink" className="btn btn-block btn-primary mt-2 " onClick={()=>peticionPost()} value="CutLink"/>
              </div>
           </div>
          </div>
        </div>
      </div>
      <br></br>
      <div className="card-body">
        <table className = "table table-bordered">
          <thead>
            <tr>
              <th>UrlOriginal</th>
              <th>UrlShorten</th>
            </tr>
          </thead>
          <tbody>
            {data.map(registro=>(
              <tr key={registro.ciRegistros}>
                <td>{registro.urlOriginal}</td>
                <td>{registro.urlShortern}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
export default App;
