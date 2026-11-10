| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  19.84 μs | 0.065 μs | 0.058 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  38.07 μs | 0.101 μs | 0.094 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  38.75 μs | 0.064 μs | 0.057 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  46.95 μs | 0.055 μs | 0.051 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  72.99 μs | 0.125 μs | 0.104 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  25.88 μs | 0.055 μs | 0.046 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  60.88 μs | 0.199 μs | 0.176 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  62.18 μs | 0.382 μs | 0.358 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  74.37 μs | 0.151 μs | 0.134 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 119.23 μs | 0.160 μs | 0.149 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  34.01 μs | 0.076 μs | 0.072 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  90.67 μs | 0.329 μs | 0.308 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  91.80 μs | 0.352 μs | 0.312 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 113.28 μs | 0.893 μs | 0.836 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 171.26 μs | 1.072 μs | 0.896 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  31.32 μs | 0.273 μs | 0.256 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  52.87 μs | 0.123 μs | 0.115 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  55.64 μs | 0.087 μs | 0.081 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  61.96 μs | 0.085 μs | 0.075 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 111.49 μs | 0.225 μs | 0.210 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  40.96 μs | 0.092 μs | 0.077 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  81.22 μs | 0.357 μs | 0.334 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  85.40 μs | 0.380 μs | 0.337 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  96.04 μs | 0.064 μs | 0.057 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 168.02 μs | 0.377 μs | 0.334 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  53.36 μs | 0.046 μs | 0.041 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 116.18 μs | 0.448 μs | 0.419 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 121.83 μs | 0.223 μs | 0.209 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 138.96 μs | 1.167 μs | 1.092 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 228.88 μs | 0.683 μs | 0.639 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  31.13 μs | 0.085 μs | 0.079 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  52.87 μs | 0.090 μs | 0.080 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  55.60 μs | 0.103 μs | 0.086 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  61.63 μs | 0.072 μs | 0.064 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 105.96 μs | 0.239 μs | 0.223 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  41.00 μs | 0.115 μs | 0.108 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  81.07 μs | 0.083 μs | 0.074 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  85.28 μs | 0.331 μs | 0.309 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  95.03 μs | 0.219 μs | 0.205 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 170.03 μs | 0.545 μs | 0.510 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  53.37 μs | 0.104 μs | 0.086 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 115.97 μs | 0.309 μs | 0.258 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 122.02 μs | 0.326 μs | 0.272 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 137.86 μs | 0.705 μs | 0.660 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 228.52 μs | 0.581 μs | 0.515 μs |   42072 B |