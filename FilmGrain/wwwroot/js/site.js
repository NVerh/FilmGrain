
function GetMovie() {
	var searchinput = document.getElementById("SButton").value;
	var api_key = '7fbd33a0ba717ecb076c4c4f2e21f824';

	$.ajax({
		url: 'https://api.themoviedb.org/3/search/movie?api_key=' + api_key + '&query=' + searchinput,
		type: "POST",
		url: '/ResultController/Index'	
		dataType: 'jsonp',
		jsonpCallback: 'testing',
		success: function (data) {
			alert(jsonpCallback[0])
			console.log(data);
		}
	})
};