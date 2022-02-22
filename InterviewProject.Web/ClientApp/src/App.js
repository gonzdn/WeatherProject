import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Weather } from './components/Weather';
import { Counter } from './components/Counter';
import NewWeather from './components/NewWeather';
import { Login } from './components/Login';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/weather' component={Weather} />
        <Route path='/login' component={Login} />
        <Route path='/newWeather' component={NewWeather} />
      </Layout>
    );
  }
}
