export const generateRatingStars = (rating) => {
    if (rating === null) {
        rating = 0;
    }
    let starsHtml = '';
    for (let i = 0; i < 5; i++) {
        if (i < Math.floor(rating)) {
            starsHtml += '<span class="rating"><img src="assets/star_filled.svg" alt="filled star"></span>';
        } else {
            starsHtml += '<span class="rating"><img src="assets/star_outlined.svg" alt="outlined star"></span>';
        }
    }
    return starsHtml;
};
