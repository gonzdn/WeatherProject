import React, { Component } from 'react';
import APIService from '../services/Api';

export class Login extends Component {
    static displayName = Login.name;

    componentDidMount() {
        this.getAuthToken();
    }

    render() {
        return (
            <div>
                <h1>You're now logged in to search for your forecast!</h1>
            </div>
        );
    }
    async getAuthToken() {
        APIService.login();
    }
}
