import cookieParser from "./ParseCookie.js"

const fetchData = async (url, method, payload, skipActions) => {
    try {
        const { token } = cookieParser()

        const skipActionsResult = {
            isAuthenticated: false,
            success: false,
            data: null
        }
        if (!["/api/register", "/api/login"].includes(url)) {
            if (!token) {
                if (skipActions) {
                    return skipActionsResult
                } else {
                    location.replace("/login.html")
                    throw new Error("User is not authenticated")
                }
            }
        }

        const BASE_URL = "http://192.168.31.198:4000"

        const rawData = await fetch(BASE_URL + url, {
            headers: {
                "Authorization": `Bearer ${token}`,
                "Content-type": "application/json"
            },
            body: payload ? JSON.stringify(payload) : undefined,
            method
        })

        let data;
        const contentType = rawData.headers.get('content-type')
        if (contentType?.includes('text')) {
            data = await rawData.text()
        } else if (contentType?.includes('json')) {
            data = await rawData.json()
        }

        if (rawData.ok) {

            if (skipActions) {
                skipActionsResult.isAuthenticated = true
                skipActionsResult.success = true
                skipActionsResult.data = data
                return skipActionsResult
            } else {
                return data
            }

        } else {
            if ([401, 403].includes(rawData.status)) {
                if (skipActions) {
                    skipActionsResult.data = data
                    return skipActionsResult
                } else {
                    location.replace("/login.html")
                    throw new Error("User is not authenticated")
                }
            }

            if (rawData.status === 400) {
                if (skipActions) {
                    skipActionsResult.isAuthenticated = true
                    skipActionsResult.success = false
                    skipActionsResult.data = data
                    return skipActionsResult
                }

                alert(JSON.stringify(data))
                throw new Error(data)
            }

            if (skipActions) {
                skipActionsResult.isAuthenticated = true
                skipActionsResult.success = false
                return skipActionsResult
            }

            alert("something went wrong")
            console.error('Status code:', rawData.status);
            throw new Error("Internal Server Error")
        }

    } catch (error) {
        throw new Error(error.message)
    }
}

export default fetchData