#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <fcntl.h>
#include <termios.h>

#define SERIAL_PORT "/dev/ttyS0"  // Su Windows: "COM1", su Ubuntu: "/dev/ttyUSB0"
#define BAUD_RATE B9600

int init_serial() {
    int fd = open(SERIAL_PORT, O_RDWR | O_NOCTTY | O_NDELAY);
    if (fd == -1) { perror("Errore apertura porta seriale"); return -1; }
    struct termios options;
    tcgetattr(fd, &options);
    cfsetispeed(&options, BAUD_RATE);
    cfsetospeed(&options, BAUD_RATE);
    options.c_cflag |= (CLOCAL | CREAD);
    options.c_cflag &= ~PARENB;
    options.c_cflag &= ~CSTOPB;
    options.c_cflag &= ~CSIZE;
    options.c_cflag |= CS8;
    tcsetattr(fd, TCSANOW, &options);
    return fd;
}

void bridge(int fd) {
    char buf[256];
    while (1) {
        int n = read(fd, buf, sizeof(buf));
        if (n > 0) { write(STDOUT_FILENO, buf, n); }
        n = read(STDIN_FILENO, buf, sizeof(buf));
        if (n > 0) { write(fd, buf, n); }
    }
}

int main() {
    int fd = init_serial();
    if (fd < 0) return 1;
    printf("Gateway seriale-TCP attivo su %s\n", SERIAL_PORT);
    bridge(fd);
    close(fd);
    return 0;
}
