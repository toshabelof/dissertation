import image_slicer
from PIL import Image
import cv2
import numpy


#work1
images = image_slicer.slice(r"C:\Users\shado\Desktop\AI_Severstal_Trash\original.jpg", 5, save=False)

for v in images:
    v.image = Image.fromarray(cv2.rectangle(numpy.array(v.image), (50, 50), (300, 100), (0, 255, 255), 10))
    # cv2.imshow("Image", numpy.array(v.image))
    # cv2.waitKey(0)

print(images)
image_slicer.join(images)
cv2.imshow("Image", numpy.array(image_slicer.join(images)))
cv2.waitKey(0)


#work2


