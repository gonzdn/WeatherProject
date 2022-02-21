import axios from 'axios'

class ApiService {
    async login() {
        await axios.post(
            `https://localhost:44377/auth/token`
        ).then(async res => {
            const data = await res.data;
            localStorage.setItem("access_token", data.access_token)
        });
    }

    getToken() {
        return localStorage.getItem("access_token");
    }

    async get(endpoint) {
        var token = this.getToken();
        var result = await axios.get(
            `https://localhost:44377/weatherforecast/${endpoint}`,
            {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }
        ).catch((error) => {
            console.log(error.message);
            return error.response;
        });

        return result;
    }
}

export default new ApiService();