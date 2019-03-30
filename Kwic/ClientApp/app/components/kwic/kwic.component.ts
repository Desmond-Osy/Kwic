import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'kwic',
    templateUrl: './kwic.component.html'
})

export class KwicComponent {
    input: String = "";
    output: String = "";
    architecture_type: String = "";
    list: String[] = this.input.split("\n");
    jsonInput = {
        "input": this.input.trim(),
        "architecture_type": this.architecture_type
    }

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {

    }

    public runKwic() {  
        //update the input field with data from control
        this.jsonInput.input = this.input.trim();
        console.log(this.jsonInput.architecture_type);

        this.http.post(this.baseUrl + 'api/Kwic', this.jsonInput).subscribe(result => {
            if (result.status == 200) {
                //console.log(result.text);
                var res = result.text().toString();

                res = res.replace("[", "");
                res = res.replace("]", "");
                for (let word of res.split(',')) {
                    res = res.replace(",", "\n");
                    res = res.replace("\"", "");
                    res = res.replace("\"", "");
        
                }

                this.output = res;
            }
        }, error => console.error(error));
    }
    
}
