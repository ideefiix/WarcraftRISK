
export function ExpiryTimeFormatter(timeStamp) {
    
    let timeDiff = new Date(timeStamp).getTime() - new Date().getTime()//In ms
    let MinutesTotal = Math.floor(timeDiff / (1000 * 60));

    let hours = Math.floor(MinutesTotal / 60);
    let minutes = (MinutesTotal % 60)
    if (hours >= 1) {

        return (`${hours} timmar ${minutes} minuter`)

    } else {
        return (`${minutes} minuter`)
    }

}