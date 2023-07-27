import requests # install it with pip install requests
import time
import random
import string

def generate_random_country_code():
    # Generate random country code with one or two letters
    letters = string.ascii_uppercase
    code_length = random.randint(1, 2)
    country_code = ''.join(random.choice(letters) for _ in range(code_length))
    return country_code

def test_api(url):
    try:
        response = requests.get(url)
        # If you need to test other HTTP methods, you can modify the requests method accordingly (e.g., requests.post, requests.put, etc.)
        
        # Check the response status code to ensure the request was successful (200 OK).
        if response.status_code == 200:
            print(f"Request successful: {response.status_code}")
        else:
            print(f"Request failed: {response.status_code}")
    except requests.RequestException as e:
        print(f"Request error: {e}")

def main():
    base_url = "http://localhost:5120/WeatherForecast/GetForecast/country?"

    for i in range(1000):
        country_code = generate_random_country_code()
        api_url = f"{base_url}country={country_code}"
        test_api(api_url)
        time.sleep(2)

if __name__ == "__main__":
    main()
