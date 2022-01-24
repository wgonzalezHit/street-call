
(async function(){
  var pedidos  = angular.module('fApp', []);
  pedidos.controller('fControler',function($scope){

   $scope.report = [];
    $scope.len=0;


  
     
     

     $scope.GetQueryResult = function() {
       $scope.report = [];

       $.urlParam = function(name){
         var url = window.location.href;
         var objt = url.split("agentsTime.html?");
    // console.log(objt[1]);
         var obj1= objt[1].split("&");
     
         var  ob= obj1[name].split("=");
          //var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
         // console.log(ob[1]);
      return ob[1];
      
         }
     var agents = $.urlParam(0);if(agents =="*"){agents =''}
     var services = $.urlParam(1);if(services =="*"){services ='';}
     var campaigns = $.urlParam(2);if(campaigns =="*"){campaigns ='';}
     var segment = $.urlParam(3);if(segment =="*"){segment ='';}
     var chanel = $.urlParam(4);if(chanel =="*"){chanel ='';}
     var ini= $.urlParam(5);
     var url ="https://omni-evo011.nobeltel.com/omniServices/Service.asmx/GetAgentTimeReport";
     //var url ="https://localhost:44318/Service.asmx/GetAgentTimeReport";
     if(ini.includes('|')){
      ini =ini.replace('|',' ');       
    }else{
      ini +=" 00:00:00";
      }

     
      var fin= $.urlParam(6); 
     
      if(fin.includes('|')){
        fin =fin.replace('|',' ');       
      }else{
        fin+=" 23:59:59";
        }
     var strjson = "{agents:'"+agents+"',services:'"+services+"',campaigns:'"+campaigns+"',segment:'"+segment+"',chanel:'"+chanel+"',ini:'"+ini+"',fin:'"+fin+"',sentido:''}";
    console.log(strjson);

     console.log(strjson);
       var settings = {
           "async": true,
           "crossDomain": true,
           "dataType": "text",
           "url": url,
           "method": "POST",
           "data": {
             "strjson":strjson.toString()
         }
           
       };

       $.get(settings, function(result) {
           $scope.$apply(function() {
               var obj = $.parseJSON(result);
               if (!obj) {
                   ToastWarning(result)
               }
              $scope.len=obj.obj.length;
              console.log($scope.len.toString()+" Length...................");
               var ttktime = 0; var tactive=0;
               for(var e=0; e<obj.obj.length;e++){
                ttktime+=parseInt(obj.obj[e].Data18);
                tactive =  parseInt(obj.obj[e].Data4);
              }
               var toccup = ttktime/tactive;
              
               for(var i=0; i<obj.obj.length;i++){
                 var elm={};
                 elm.agent=obj.obj[i].Data1.toString();
                 elm.contacts=parseInt(obj.obj[i].Data2).toString();
                 elm.ca=parseInt(obj.obj[i].Data3).toString();
                 elm.Data4=parseFloat(obj.obj[i].Data4);
                 
                 if(parseInt(obj.obj[i].Data4)>0){
                  elm.cah=(parseFloat(obj.obj[i].Data3)/(parseFloat(obj.obj[i].Data4)/60/60)).toFixed(2);
                 }else{
                  elm.cah=0;
                 }
                 
                 elm.cna=parseInt(obj.obj[i].Data5).toString();
                 elm.cna60=parseInt(obj.obj[i].Data6).toString();
                 elm.repondeur=parseInt(obj.obj[i].Data7).toString();
                 elm.rep60=parseInt(obj.obj[i].Data8).toString();
                 elm.recuperation=parseInt(obj.obj[i].Data9);
                 elm.encours=parseInt(obj.obj[i].Data10).toString();
                 elm.positif=parseInt(obj.obj[i].Data11).toString();
                 elm.session=new Date(parseFloat(obj.obj[i].Data12) * 1000).toISOString().substr(11, 8);//getTime(obj.obj[i].Data12);
                 elm._session = obj.obj[i].Data12;
                 elm.average=new Date(parseFloat(obj.obj[i].Data13) * 1000).toISOString().substr(11, 8);//getTime(obj.obj[i].Data13);
                 elm._average=obj.obj[i].Data13;
                 elm.callbaks=parseInt(obj.obj[i].Data14);
                 elm.breaks=new Date(parseFloat(obj.obj[i].Data15) * 1000).toISOString().substr(11, 8);
                 elm._breaks=obj.obj[i].Data15;
                 elm.available=new Date(parseFloat(obj.obj[i].Data16) * 1000).toISOString().substr(11, 8);//getTime(obj.obj[i].Data16);
                 elm._available=obj.obj[i].Data16;
                 elm.preview=new Date(parseFloat(obj.obj[i].Data17) * 1000).toISOString().substr(11, 8);//getTime(obj.obj[i].Data17);
                 elm._preview=obj.obj[i].Data17;
                 elm.talktime=new Date(parseFloat(obj.obj[i].Data18) * 1000).toISOString().substr(11, 8);
                 elm._talktime = obj.obj[i].Data18;
                 elm.wrapup =new Date(parseFloat(obj.obj[i].Data19) * 1000).toISOString().substr(11, 8);//getTime(obj.obj[i].Data19);
                 elm._wrapup=obj.obj[i].Data19;
                 if(parseInt(obj.obj[i].Data4)>0){
                  //elm.occup=(((parseFloat(obj.obj[i].Data18))/((parseFloat(obj.obj[i].Data12)-parseFloat(obj.obj[i].Data15))))*100).toFixed(2).toString()+"%";
				  elm.occup=(((parseFloat(obj.obj[i].Data18))/(parseFloat(obj.obj[i].Data4)-parseFloat(obj.obj[i].Data15)))*100).toFixed(2).toString()+"%";
				  elm.occup2=(parseFloat(obj.obj[i].Data18)/(parseFloat(obj.obj[i].Data4)-parseFloat(obj.obj[i].Data15)));
                 }else{elm.occup="0.00%"; elm.occup2="0.00";}

                 if(parseInt(obj.obj[i].Data11)>0){
                    elm.concret=((parseInt(obj.obj[i].Data11)/parseInt(obj.obj[i].Data3))*100).toFixed(2).toString()+"%";
					if(parseInt(obj.obj[i].Data3) >0){elm.concret2=(parseInt(obj.obj[i].Data11)/parseInt(obj.obj[i].Data3))}else{elm.concret2="0";};
					//console.log(elm.concret2);
                 }else{elm.concret="0"; elm.concret2="0";}

                 $scope.report.push(elm);
                }
           
             
              
           });
       });
     
       
   };

   function getTime(t){
    dt = new Date(t);
    var h= dt.getHours();
    var m = dt.getMinutes();
    var s= dt.getSeconds();  
    return pad(h)+":"+pad(m)+":"+pad(s);
   }
   function pad(num) {
    if(num < 10) {
      return "0" + num;
    } else {
      return "" + num;
    }
  }

  function getSeconds(time){
       // your input string
    var a = time.split(':'); // split it at the colons
    // minutes are worth 60 seconds. Hours are worth 60 minutes.
    var seconds = (+a[0]) * 60 * 60 + (+a[1]) * 60 + (+a[2]); 
    return seconds;
  }

   $scope.GetQueryResult();
   

   $scope.contacts=function(){
     var tot=0;
     for(var i=0; i<$scope.report.length;i++){
       tot+=parseInt($scope.report[i].contacts);
     } 
      return tot;
   }
   $scope.ca=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].ca);
    } 
     return tot;
  }
  $scope.cah=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseFloat($scope.report[i].cah);
    } 
     return (tot/$scope.len).toFixed(2);
  }


  $scope.cna=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].cna);
    } 
     return tot;
  }
  $scope.cna60=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].cna60);
    } 
     return tot;
  }

  $scope.respondeur=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].repondeur);
    } 
     return tot;
  }
  $scope.resp60=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].rep60);
    } 
     return tot;
  }
  $scope.recuperation=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].recuperation);
    } 
     return tot;
  }
  $scope.encours=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].encours);
    } 
     return tot;
  }

  $scope.positives=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].positif);
    } 
     return tot;
  }

  $scope.occup=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=((parseFloat($scope.report[i].Data18)/parseFloat($scope.report[i].Data18))/60/60).toFixed(2);
    } 
     return tot;
  }

 
  
  $scope.callbacks=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i].callbaks);
    } 
     return tot;
  }

  //******************************************************************Session AVerage */
  $scope._session=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._session);
    } 
    tot = tot/$scope.len;
    tot = new Date(parseFloat(tot) * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
  $scope._average=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._average);
    } 
    tot = tot/$scope.len;
    tot = new Date(parseFloat(tot) * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
  $scope._breaks=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._breaks);
    } 
    tot = tot/$scope.len;
    console.log("to..: "+tot.toString());
    tot = new Date(tot * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
  $scope._available=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._available);
    } 
    tot = tot/$scope.len;
    tot = new Date(tot * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
  $scope._preview=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._preview);
    } 
    tot = tot/$scope.len;
    tot = new Date(tot * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
  $scope._talktime=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._talktime);
    } 
    tot = tot/$scope.len;
    tot = new Date(tot * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
  $scope._wrapup=function(){
    var tot=0;
    for(var i=0; i<$scope.report.length;i++){
      tot+=parseInt($scope.report[i]._wrapup);
    } 
    tot = tot/$scope.len;
    tot = new Date(tot * 1000).toISOString().substr(11, 8) 
    return tot.toString();
  }
  //******************************************************************************* */
     $scope._concret=function(){
     var tot=0;
     for(var i=0; i<$scope.report.length;i++){
      
	  tot+=parseFloat($scope.report[i].concret2);
     } 

      return ((tot / $scope.len)*100).toFixed(2).toString()+"%";
   }

   $scope._occup=function(){
     var tot=0;
     for(var i=0; i<$scope.report.length;i++){
      
	  tot+=parseFloat($scope.report[i].occup2);
     } 

      return ((tot / $scope.len)*100).toFixed(2).toString()+"%";
   }


  
$scope.tocsv = function(){
	console.log("downloading.....");
  downloadToCsv($scope.report,$scope.contacts(),$scope.ca(),$scope.cah(),$scope.cna(),$scope.cna60(),$scope.respondeur(),$scope.resp60(),$scope.recuperation(), $scope.encours(),$scope.positives(),$scope.callbacks(),$scope._session(),$scope._average(),$scope._breaks(),$scope._available(),$scope._preview(),$scope._talktime(),$scope._wrapup(),$scope._occup(),$scope._concret());
}	
    

});

 
}());
var XLS="";
function downloadToCsv(report,contacts,ca,cah,cna,cna60,respondeur,resp60,recuperation,encours,positif,callbacks,_session,_average,_breaks,_available,_preview,_talktime,_wrapup,_occup,_concret){
  console.log("Dowloading............"+ report.length.toString());
  var csv = 'Agent,Contacts,CA,CNA,Respondeur,Positives,CNA>60,Resp>60,Session,CallBacks,CA/Hr,Breaks,Available,Preview,Talk Time,Wrapup Time';
  var totalr=0;
    var rows = new Array(report.length + 1);	
    rows[0] = new Array(17);
    rows[0][0] = "Agents";
    rows[0][1] = "Contacts";
    rows[0][2] = "CA";
    rows[0][3] = "CA/H";
    rows[0][4] = "CNA";
    rows[0][5] = "CNA>60";
    rows[0][6] = "Rep";
    rows[0][7] = "Rep>60";
    rows[0][8] = "Recup";
    rows[0][9] = "Encours";
    rows[0][10] = "Positif";
    rows[0][11] = "CallBacks";
    rows[0][12] = "Session";
    rows[0][13] = "DMT";
    rows[0][14] = "Breaks";
    rows[0][15] = "Disponible";
    rows[0][16] = "Preview";
    rows[0][17] = "Talk Time";
    rows[0][18] = "Wrap up Time";
    rows[0][19] = "Occup%";
    rows[0][20] = "Concret%";


    for(var i=0;i<report.length+1;i++){
          if(i==report.length){
            rows[i + 1] = new Array(17);
            rows[i + 1][0] = "TOTAL";
            rows[i + 1][1] = contacts;	
            rows[i + 1][2] = ca;	
            rows[i + 1][3] =cah;	
            rows[i + 1][4] = cna;
            rows[i + 1][5] = cna60;
            rows[i + 1][6] = respondeur;
            rows[i + 1][7] = resp60;
            rows[i + 1][8] = recuperation;
            rows[i + 1][9] = encours;
            rows[i + 1][10] = positif;
            rows[i + 1][11] = callbacks;
            rows[i + 1][12] = _session;
            rows[i + 1][13] = _average;
            rows[i + 1][14] = _breaks;
            rows[i + 1][15] = _available;
            rows[i + 1][16] = _preview;
            rows[i + 1][17] = _talktime;
            rows[i + 1][18] = _wrapup;
            rows[i + 1][19] = _occup;
            rows[i + 1][20] = _concret;
            

            }else{
            rows[i + 1] = new Array(17);
            rows[i + 1][0] = report[i].agent;
            rows[i + 1][1] = report[i].contacts;
            rows[i + 1][2] = report[i].ca;
            rows[i + 1][3] = report[i].cah;
            rows[i + 1][4] = report[i].cna;
            rows[i + 1][5] = report[i].cna60;
            rows[i + 1][6] = report[i].repondeur;
            rows[i + 1][7] = report[i].rep60;
            rows[i + 1][8] = report[i].recuperation;
            rows[i + 1][9] = report[i].encours;
            rows[i + 1][10] =report[i].positif;
            rows[i + 1][11] =report[i].callbaks;
            rows[i + 1][12] =report[i].session;
            rows[i + 1][13] =report[i].average;
            rows[i + 1][14] =report[i].breaks;
            rows[i + 1][15] =report[i].available;
            rows[i + 1][16] =report[i].preview;
            rows[i + 1][17] =report[i].talktime;
            rows[i + 1][18] =report[i].wrapup;
            rows[i + 1][19] =report[i].occup;
            rows[i + 1][20] =report[i].concret;
           
          }
      }
  console.log("xls go");
    if(typeof require !== 'undefined' && typeof XLSX === 'undefined') XLSX = require('xlsx');
    var ws = XLSX.utils.json_to_sheet(rows);
    var wb = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, "Hoja1");
    var d = new Date();
    var m = parseInt(d.getMonth()) + 1;
    XLSX.writeFile(wb, "Flash_Prod_"+ m + "/" + d.getDate() + "/" + d.getFullYear() + "_" + d.getHours() + d.getMinutes() + d.getSeconds() + ".xlsx");
  
    
  }
