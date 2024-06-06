const darkColors = [
    '#538392',
    '#D20062',
    '#254336',
    '#5BBCFF',
    '#028391',
    '#003285',
    '#344C64', 
    '#DC6B19',
    '#3C5B6F',
    '#074173', 
];


export const randomColor = () => {
    const randomIndex = Math.floor(Math.random() * darkColors.length);
    return darkColors[randomIndex];
}

