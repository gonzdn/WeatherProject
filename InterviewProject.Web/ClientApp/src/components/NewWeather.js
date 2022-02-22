import React, { useState } from 'react';
import APIService from '../services/Api';
import Card from '../features/Card';

function NewWeather() {
    const [text, setText] = useState('');
    const [suggestions, setSuggestions] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(false);
    const [errorMsg, setErrorMsg] = useState('');
    const [showForecasts, setShowForecasts] = useState(false);
    const [forecasts, setForecasts] = useState([]);

    const onChangeHandler = async (text) => {
        setText(text);
        if (text.length > 2) {
            const response = await APIService.get('GetLocationSearch?query=' + text);
            if (validate200Status(response.status)) {
                setSuggestions(response.data);
            }
        }
    }

    const onSuggestionHandler = async (suggestion) => {
        setText(suggestion.title);
        setLoading(true);
        setShowForecasts(false);
        setSuggestions([]);
        const response = await await APIService.get('GetSearch?woeid=' + suggestion.woeid);
        if (validate200Status(response.status)) {
            setForecasts(response.data);
            setLoading(false);
            setShowForecasts(true);
        }
    }

    const validate200Status = (status) => {
        if (status == 401) {
            setErrorMsg("Not authorized, please go to login page and then come back.")
            setLoading(false);
            setError(true);
            return false;
        }
        if (status != 200) {
            setErrorMsg("Unkown error.")
            setLoading(false);
            setError(true);
            return false;
        }
        return true;
    }

    return (
        <div className="container">
            <h1 id="tabelLabel">Weather forecast</h1>
            <p>Type your location to search for your next 5 days weather forecast.</p>
            <input
                className="form-control"
                type="text"
                placeholder="Enter 3 letters to search..."
                onChange={async e => await onChangeHandler(e.target.value)}
                value={text}
            />
            {suggestions && suggestions.map((suggestion, i) =>
                <div key={i}
                    className="suggestion justify-content-md-center"
                    onClick={() => onSuggestionHandler(suggestion)}
                >
                    {suggestion.title}</div>
            )}
            <br />
            {loading && <p> <em>Loading Weather Forecast...</em></p>}
            {error && <div>
                <p style={{ color: "red" }}>{errorMsg}</p>
            </div>}
            {showForecasts &&
                <div className="row">
                    {forecasts.consolidated_weather.slice(1, 6).map(forecast =>
                        <div className="col-md-4" key={forecast.id}>
                            <Card item={forecast} />
                        </div>
                    )}
                </div>
            }
        </div>
    );
}

export default NewWeather;