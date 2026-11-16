| Description                                                  | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |----------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |  19.94 μs | 0.129 μs | 0.114 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  38.36 μs | 0.417 μs | 0.390 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  38.84 μs | 0.204 μs | 0.170 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  46.80 μs | 0.104 μs | 0.097 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  78.30 μs | 0.301 μs | 0.281 μs |   15560 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-768 · OS                                |  25.90 μs | 0.072 μs | 0.068 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  61.27 μs | 0.437 μs | 0.388 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  63.18 μs | 1.231 μs | 1.265 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  76.59 μs | 0.340 μs | 0.302 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 121.00 μs | 1.803 μs | 1.686 μs |   25120 B |
|                                                              |           |          |          |           |
| Encapsulate · ML-KEM-1024 · OS                               |  34.04 μs | 0.144 μs | 0.128 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  91.87 μs | 1.428 μs | 1.336 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  92.42 μs | 0.935 μs | 0.874 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 111.92 μs | 1.106 μs | 0.980 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 172.71 μs | 1.876 μs | 1.465 μs |   37248 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-512 · OS                                |  31.51 μs | 0.375 μs | 0.351 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  52.87 μs | 0.246 μs | 0.192 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  55.99 μs | 0.647 μs | 0.605 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  61.76 μs | 0.168 μs | 0.140 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 112.19 μs | 0.623 μs | 0.583 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-768 · OS                                |  41.16 μs | 0.330 μs | 0.293 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  81.15 μs | 0.692 μs | 0.613 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  84.69 μs | 0.604 μs | 0.504 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  95.29 μs | 0.689 μs | 0.644 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 171.04 μs | 2.225 μs | 2.081 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate · ML-KEM-1024 · OS                               |  53.87 μs | 0.488 μs | 0.433 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 117.01 μs | 1.383 μs | 1.226 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 123.25 μs | 2.167 μs | 2.027 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 139.69 μs | 2.169 μs | 1.922 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 239.91 μs | 4.641 μs | 4.966 μs |   42072 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  31.76 μs | 0.471 μs | 0.441 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  53.54 μs | 0.291 μs | 0.258 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  55.73 μs | 0.200 μs | 0.187 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  61.24 μs | 0.242 μs | 0.227 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 105.66 μs | 0.535 μs | 0.474 μs |   17952 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  41.36 μs | 0.525 μs | 0.466 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  80.81 μs | 0.552 μs | 0.461 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  86.14 μs | 0.901 μs | 0.842 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  95.04 μs | 0.430 μs | 0.402 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 163.89 μs | 1.354 μs | 1.200 μs |   28408 B |
|                                                              |           |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  53.61 μs | 0.223 μs | 0.187 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 117.99 μs | 2.228 μs | 2.188 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 121.51 μs | 0.777 μs | 0.727 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 137.01 μs | 0.391 μs | 0.327 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 228.22 μs | 1.472 μs | 1.377 μs |   42072 B |