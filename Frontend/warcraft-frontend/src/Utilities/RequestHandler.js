
export function ValidateRequest(data){
    if(data == null) return false;

    if(data.status > 299 || data.status < 200) return false

    // The request is OK
    return true;
}