function getRequest() {
  var url = location.search //获取url中"?"符后的字串
  var theRequest = new Object()
  if (url.indexOf('?') !== -1) {
    var str = url.substr(1)
    var strs = str.split('&')
    for (var i = 0; i < strs.length; i++) {
      theRequest[strs[i].split('=')[0]] = unescape(strs[i].split('=')[1])
    }
  }
  return theRequest
}
req = getRequest()

function ajax(data, call) {
  var url = 'http://localhost:53666/api' + data.url
  $.ajax({
    type: data.type,
    url: url,
    data: data.data,
    xhrFields: { withCredentials: true },
    success: function(d) {
      call(d)
    },
    error(err) {
      if (err.status == 401) {
        location.href = 'login.html?url=' + location.href
      } else if (err.status == 500) {
        alert(err.responseText)
      } else if (err.status == 409) {
        if (req.url) {
          location.href = req.url
        } else {
          location.href = 'Dome.html'
        }
      }
      console.log(err)
    }
  })
}
