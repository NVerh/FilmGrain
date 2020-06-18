
function GetMovie() {
	var searchinput = document.getElementById("SButton").value;
	var api_key = '7fbd33a0ba717ecb076c4c4f2e21f824';

	$.ajax({
		url: 'https://api.themoviedb.org/3/search/movie?api_key=' + api_key + '&query=' + searchinput,
		dataType: 'jsonp',
		jsonpCallback: 'testing',
	}).error(function () {
		console.log('error')
	}).done(function (response) {
		for (var i = 0; i < response.results.length; i++) {
			$('#search_results').append('<li>' + response.results[i].title + '</i>');
		}
	})
}
function toggleText() {
	var text = document.getElementById("favText");
	if (text.style.display === "none") {
		text.style.display = "block";
	} else {
		text.style.display = "none";
	}
}