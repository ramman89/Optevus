
import axios from "axios";
class HttpService {
    async GetPolicyDetails() {
        try {
            var response = await axios.get('http://localhost:1811/api/Policy/Data');
            return response.data;
        } catch (error) {
            console.log(JSON.stringify(error));
        }
    }

    async UpdatePolicyDetails(payload) {
        try {
            let options = {
                headers: {
                    "Content-Type": "application/json",
                },
            };
            payload.bodilyInjury=(payload.bodilyInjury?.toLowerCase()=='true'?true:false);
            payload.customerMaritalStatus=(payload.customerMaritalStatus?.toLowerCase()=='true'?true:false);
            var response = await axios.post('http://localhost:1811/api/Policy/SavePolicy',JSON.stringify(payload), options);
            return response;
        } catch (error) {
            console.log(JSON.stringify(error));
        }
    }

    async GetReportData(origin) {
        try {
            var response = await axios.get('http://localhost:1811/api/Policy/ReportData?origin='+origin);
            return response.data;
        } catch (error) {
            console.log(JSON.stringify(error));
        }
    }
}

const httpService = new HttpService();

export { httpService }