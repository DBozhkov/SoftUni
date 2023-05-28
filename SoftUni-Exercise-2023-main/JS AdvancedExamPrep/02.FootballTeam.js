class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {
        let playerNames = [];

        for (let playerInfo of footballPlayers) {
            let splittedInfo = playerInfo.split('/');
            let player = {};

            player['playerName'] = splittedInfo[0];
            player['playerAge'] = Number(splittedInfo[1]);
            player['playerValue'] = Number(splittedInfo[2]);

            if (!this.invitedPlayers.some(x => x.playerName == player['playerName'])) {
                this.invitedPlayers.push(player);
                playerNames.push(player['playerName']);
            } else {
                let index = this.invitedPlayers.findIndex(x => x.playerName == player['playerName']);
                if (this.invitedPlayers[index].playerValue > player['playerValue']) {
                    this.invitedPlayers[index].playerValue = player['playerValue'];
                }
                else {
                    continue;
                }
            }
        }

        return `You successfully invite ${playerNames.join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let splittedSelectedPlayer = selectedPlayer.split('/');
        let selectedPlayerName = splittedSelectedPlayer[0];
        let selectedPlayerOffer = Number(splittedSelectedPlayer[1]);

        if (!this.invitedPlayers.some(x => x.playerName == selectedPlayerName)) {
            throw new Error(`${selectedPlayerName} is not invited to the selection list!`);
        }

        let selectedIndex = this.invitedPlayers.findIndex(x => x.playerName == selectedPlayerName);

        if (this.invitedPlayers[selectedIndex].playerValue > selectedPlayerOffer) {
            let priceDifference = this.invitedPlayers[selectedIndex].playerValue - selectedPlayerOffer;
            throw new Error(`The manager's offer is not enough to sign a contract with ${selectedPlayerName}, ${priceDifference} million more are needed to sign the contract!`);
        } else {
            this.invitedPlayers[selectedIndex].playerValue = 'Bought';
        }
        return `Congratulations! You sign a contract with ${selectedPlayerName} for ${selectedPlayerOffer} million dollars.`;
    }

    ageLimit(name, age){
        if (!this.invitedPlayers.some(x => x.playerName == name)) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        let limitIndex = this.invitedPlayers.findIndex(x => x.playerName == name);

        if (this.invitedPlayers[limitIndex].playerAge < age) {
            let ageDifference = age - this.invitedPlayers[limitIndex].playerAge;
            if(ageDifference < 5){
                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            } else if(ageDifference > 5){
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            } 
        } else {
            return `${name} is above age limit!`;
        }
    }

    transferWindowResult(){
        this.invitedPlayers = this.invitedPlayers.sort((a, b) => (a.playerName).localeCompare(b.playerName));
        let finalNames = [];
        let finalValues = [];
        let playerInfoArray = [];
        for (const player of this.invitedPlayers) {
            finalNames.push(player.playerName);
            finalValues.push(player.playerValue);
        }
        for(let i = 0; i < finalNames.length; i++){
            playerInfoArray.push(`Player ${finalNames[i]}-${finalValues[i]}`);
        }
        return `Players list:\n${playerInfoArray.join('\n')}`;
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());
