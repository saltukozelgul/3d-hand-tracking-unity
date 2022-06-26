import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

# UDP Server
socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
serverAdress = ("127.0.0.1", 24000)

height = 480
width = 640


cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)

detector = HandDetector(maxHands=1)


while True:
    success, img = cap.read()

    hands , img = detector.findHands(img)

    data = []
    if hands:
        hand = hands[0]
        landmarkList = hand['lmList']


        for lm in landmarkList:
            data.append(lm[0])
            data.append(height - lm[1])
            data.append(lm[2])
        socket.sendto(str.encode(str(data)),serverAdress)

    cv2.imshow("Image",img)
    cv2.waitKey(1)



