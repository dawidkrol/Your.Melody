from flask import Flask, request, jsonify
from difflib import SequenceMatcher

app = Flask(__name__)

@app.route('/compare', methods=['POST'])
def compare():
    string1 = request.json['string1']
    string2 = request.json['string2']
    similarity = SequenceMatcher(None, string1, string2).ratio() * 100
    return jsonify({'similarity': similarity})

if __name__ == '__main__':
    app.run(debug=True)
