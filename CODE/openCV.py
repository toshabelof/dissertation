# opencv-python
# cvlib
# matplotlib
# tensorflow

import cv2
import matplotlib.pyplot as plt
import cvlib as cv
from cvlib.object_detection import draw_bbox

import time

def Detection(frame):
    bbox, label, conf = cv.detect_common_objects(frame, model='yolov3')
    output_image = draw_bbox(frame, bbox, label, conf)
    return output_image

def main():
    start_time = time.time()
    im = cv2.imread(r"C:\Users\shado\Desktop\AI_Severstal_Trash\670.jpg")
    print('cv2.imread %a' % (time.time() - start_time))

    start_time = time.time()
    bbox, label, conf = cv.detect_common_objects(im, model='yolov3')
    print('cv.detect_common_objects %a' % (time.time() - start_time))

    start_time = time.time()
    output_image = draw_bbox(im, bbox, label, conf)
    print('draw_bbox %a' % (time.time() - start_time))

    plt.imshow(output_image)
    plt.show()

def CamWork():
    cap = cv2.VideoCapture(0)
    while (True):
        ret, frame = cap.read()
        frame = Detection(frame)
        cv2.imshow('Video', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

if __name__ == "__main__":
    main()
    #CamWork()