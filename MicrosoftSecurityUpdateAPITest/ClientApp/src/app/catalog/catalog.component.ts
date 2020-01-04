import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
    selector: 'app-catalog',
    templateUrl: './catalog.component.html'
})

export class CatalogComponent {
    
    public patches: Patches[];
    public patchesFiltered: Patches[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string){
        http.get<Patches[]>(baseUrl + 'api/patch').subscribe(result => {
            this.patches = result;
            this.patchesFiltered = result;
        }, error => console.error(error));
    }

    filterKB(code: string){
        let patches = this.patches;
        this.patchesFiltered = patches.filter(p => p.remediationDescription.includes(code.toUpperCase()));
    }
}

interface Patches
{
    remediationDescription: string;
    patchAlias: string;
    remediationUrl: string;
    strPatchInitialReleaseDate: string;
    strPatchCurrentReleaseDate: string;
}



