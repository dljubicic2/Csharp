import React,  { Component } from "react";
import { Container, Table } from "react-bootstrap";


export default class Osobe extends Component{
    
    
    render(){
        return (


            <Container>
                <a href="/osobe/dodaj" className="btn btn-success gumb">
                    Dodaj novu osobu
                </a>

            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Nadimak</th>
                        <th>Email</th>
                        <th>Lozinka</th>
                    </tr>
                </thead>
                <tbody>
                    {/* Ovdje će doći podaci s backend-a */ }
                </tbody>
            </Table>
            

            

            </Container>
            



        );
    }
}