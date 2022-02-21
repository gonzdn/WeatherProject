import React from 'react';

function Card(props) {
    return (
        <div className="card" style={{ width: "20rem" }}>
            <div className="text-center">
                <img className="card-img-top"
                    style={{ width: "50px" }}
                    src={'https://www.metaweather.com/static/img/weather/' + props.item.weather_state_abbr + '.svg'}
                    alt="Weather Card" />
            </div>

            <div className="card-body">
                <h5 className="card-title text-center">{props.item.weather_state_name}</h5>
                <p className="h3 text-center"><b>{Math.trunc(props.item.the_temp)} &#8451;</b></p>
                <p className="text-center">{new Date(props.item.applicable_date).toLocaleString('en-us', { weekday: 'long' })} {new Date(props.item.applicable_date).getDate()}</p>
                <p className="text-center">Day <b>{Math.trunc(props.item.max_temp)}&#8451;</b> | Night <b>{Math.trunc(props.item.min_temp)}&#8451;</b></p>
                <table className="table-responsive table-body table-bordered table-hover">
                    <tbody>
                        <tr>
                            <td>Wind</td>
                            <td>{props.item.wind_direction_compass}</td>
                            <td>Humidity</td>
                            <td>{props.item.humidity}</td>
                        </tr>
                        <tr>
                            <td>Wind Speed</td>
                            <td>{props.item.wind_speed}</td>
                            <td>Air Pressure</td>
                            <td>{props.item.air_pressure}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default Card;