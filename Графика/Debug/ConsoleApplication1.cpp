#include <iostream>
#include "glut.h"

void drawBahamasFlag() {
    glClearColor(0.055, 0.463, 0.62, 0.0); // Set the background color to blue
    glClear(GL_COLOR_BUFFER_BIT);     // Clear the color buffer

    // Draw the aquamarine, gold, and aquamarine stripes
    glBegin(GL_QUADS);
    
    // Aquamarine stripe (bottom)
    glColor3f(0.055, 0.463, 0.62);
    glVertex2f(-1.0, 0.2);
    glVertex2f(1.0, 0.2);
    glVertex2f(1.0, -1.0);
    glVertex2f(-1.0, -1.0);

    // Gold stripe (middle)
    glColor3f(0.871, 0.922, 0.055);
    glVertex2f(-1.0, 0.2);
    glVertex2f(1.0, 0.2);
    glVertex2f(1.0, -0.2);
    glVertex2f(-1.0, -0.2);

    glEnd();

    // Draw the black equilateral triangle
    glBegin(GL_TRIANGLES);
    glColor3f(0.0, 0.0, 0.0);
    glVertex2f(-1, -0.5);
    glVertex2f(-1, 0.5);
    glVertex2f(-0.2, 0);
    glEnd();

    glutSwapBuffers();
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
    glutInitWindowSize(800, 600);
    glutCreateWindow("Bahamas Flag");

    glutDisplayFunc(drawBahamasFlag);


    glutMainLoop();

    return 0;
}