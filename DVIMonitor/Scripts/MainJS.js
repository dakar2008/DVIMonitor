document.addEventListener('DOMContentLoaded', () => {

    const feedUrl = ['http://localhost:65227/Content/newsfeed.xml'
    ];

    const elementSelector = document.getElementById('marquee');

    new RSSMarquee(feedUrl, elementSelector, {
        speed: 105,
        maxItems: 60
    });
});