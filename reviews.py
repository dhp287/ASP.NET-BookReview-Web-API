import requests
import json

url = 'https://api.nytimes.com/svc/books/v3/reviews.json?author=Stephen+King&api-key=N8GLrVSFRzVMSz8dA3Cjw5NJaso2gOJa'

r = requests.get(url=url)

data = r.json()

review_list = []

for row in data['results']:
    review = {
        'BookTitle': row['book_title'],
        'Url': row['url'],
        'PublicationDt': row['publication_dt'],
        'Byline': row['byline'],
        'BookAuthor': row['book_author'],
        'Summary': row['summary']
    }
    review_list.append(review)

url = 'http://localhost:62078/odata/BookReviews/'
token = 'GZyZbG0yMDQtL26kV43djgTBj2k1jseKqrPJieeXORRMUEM4gSvnRcoQO2wmP3Ee8xN9udONCtBwqh6HZjWOkl-p-El7C3WW7B8dDsapE6oCgCrAWc1Fm7vn_IicYYcW-nImBb11AuKijbKJgUa48ipjj7Z9d62fC3KR41QNnzq1gy5-4sobtltCJcLPoAHayzMB0ZmFNkbFzJllQGm4fWmh0CeUjKkzTCb3_a7XCIso5zw6hV1AmkG7HMrksNaxenWr3kVbsFnYbWH01B8jnGJ7BffGIKvZ6QD-zhEEJNSZfhWm8OhNS9bOjJdpwnSgxhY8konQWcx81Csqfao6FuukhWFeFFHG-0a9iArCFP8g73DTcnapvjo0TztwqmcqugLt3xAcpohirz7GO5BxNGEnCSVZ3eWEov1vPX39rhjC0l7ZnKn1sThjqeEpp-i9i1O7iuwSnVG6F2Qq-9Mfq9aUTN_NgCMjgEtxdzb14D4'
headers = {'Content-Type': 'application/json',
           'Authorization': 'Bearer ' + token}
for i in review_list:
    r = requests.post(url, data=json.dumps(i), headers=headers)
    print(r)