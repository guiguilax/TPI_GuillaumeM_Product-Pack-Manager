
var nodes = 
	[
  {
    "id": 257,
    "label": "Pack 20 M\n id 257 elementid 1592",
    "color": "#810000",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  },
  {
    "id": 263,
    "label": "SURF_10M_vnk\n id 263 elementid 1193",
    "color": "#810000",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  },
  {
    "id": 264,
    "label": "Ligne de raccordement\n id 264 elementid 467",
    "color": "#810000",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  },
  {
    "id": 265,
    "label": "TG 784\n id 265 elementid 212",
    "color": "#fed049",
    "shape": "box",
    "font": {
      "color": "#114e60"
    }
  },
  {
    "id": 266,
    "label": "Pack Fibre VTXbox (BBCS-F)\n id 266 elementid 373",
    "color": "#fed049",
    "shape": "box",
    "font": {
      "color": "#114e60"
    }
  },
  {
    "id": 267,
    "label": "Phone_Confort\n id 267 elementid 1197",
    "color": "#810000",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  },
  {
    "id": 268,
    "label": "VTX_TV\n id 268 elementid 1297",
    "color": "#810000",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  },
  {
    "id": 269,
    "label": "Set-top box TV (v2)\n id 269 elementid 634",
    "color": "#fed049",
    "shape": "box",
    "font": {
      "color": "#114e60"
    }
  },
  {
    "id": 270,
    "label": "Option TV : Replay 7 jours et Enregistrement\n id 270 elementid 4536",
    "color": "#007580",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  },
  {
    "id": 271,
    "label": "End",
    "color": "#81b214",
    "shape": "box",
    "font": {
      "color": "#f4eee8"
    }
  }
]
;
var edges = 
	[
  {
    "from": 263,
    "to": 265,
    "label": "CREATE/GETEXISTING"
  },
  {
    "from": 265,
    "to": 264,
    "label": "CREATE/CREATEORREUSE"
  },
  {
    "from": 268,
    "to": 269,
    "label": "CREATE/GETEXISTING"
  },
  {
    "from": 269,
    "to": 270,
    "label": "CREATE/CREATEORREUSE"
  },
  {
    "from": 266,
    "to": 267,
    "label": ""
  },
  {
    "from": 270,
    "to": 271,
    "label": ""
  },
  {
    "from": 267,
    "to": 268,
    "label": ""
  },
  {
    "from": 264,
    "to": 267,
    "label": ""
  },
  {
    "from": 257,
    "to": 263,
    "label": ""
  }
]
;