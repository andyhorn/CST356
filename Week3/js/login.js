const USERNAME = 'username'
const PASSWORD = 'password'
const U_ERR = 'username-error'
const P_ERR = 'password-error'

function setVisible(id, isVisible) {
    let item = document.getElementById(id)
    item.style.visibility = isVisible ? 'visible' : 'hidden'
}

function getContent(id) {
    return document.getElementById(id).value
}

function hasContent(id) {
    return getContent(id) != ""
}

function validate() {

    setVisible(U_ERR, false)
    setVisible(P_ERR, false)

    if (!hasContent(USERNAME)) {
        setVisible(U_ERR, true)
    }

    if (!hasContent(PASSWORD)) {
        setVisible(P_ERR, true)
    }
}