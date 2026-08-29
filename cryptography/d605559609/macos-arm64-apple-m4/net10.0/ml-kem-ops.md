| Description                                                  | Mean     | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |---------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · CryptoHives                       | 14.63 μs | 0.083 μs | 0.069 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             | 14.76 μs | 0.011 μs | 0.010 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      | 16.47 μs | 0.149 μs | 0.124 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          | 29.84 μs | 0.299 μs | 0.250 μs |   15560 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-768 · CryptoHives                       | 23.27 μs | 0.155 μs | 0.145 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             | 23.42 μs | 0.042 μs | 0.037 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      | 25.93 μs | 0.020 μs | 0.016 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 46.88 μs | 0.087 μs | 0.077 μs |   25120 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-1024 · CryptoHives                      | 33.84 μs | 0.070 μs | 0.062 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 34.49 μs | 0.016 μs | 0.015 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 38.40 μs | 0.055 μs | 0.048 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 70.46 μs | 0.071 μs | 0.063 μs |   37248 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-512 · CryptoHives                       | 20.90 μs | 0.028 μs | 0.026 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             | 21.92 μs | 0.011 μs | 0.010 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      | 22.50 μs | 0.006 μs | 0.005 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 40.32 μs | 0.093 μs | 0.087 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-768 · CryptoHives                       | 31.47 μs | 0.031 μs | 0.026 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             | 33.00 μs | 0.021 μs | 0.018 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      | 34.51 μs | 0.020 μs | 0.017 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 63.61 μs | 0.101 μs | 0.090 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 44.61 μs | 0.026 μs | 0.023 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 46.97 μs | 0.027 μs | 0.021 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 49.61 μs | 0.030 μs | 0.025 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 91.39 μs | 0.262 μs | 0.233 μs |   42072 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            | 20.89 μs | 0.024 μs | 0.021 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  | 21.92 μs | 0.032 μs | 0.029 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           | 22.52 μs | 0.016 μs | 0.013 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 39.83 μs | 0.046 μs | 0.039 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            | 31.47 μs | 0.019 μs | 0.015 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  | 33.00 μs | 0.025 μs | 0.022 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           | 34.41 μs | 0.019 μs | 0.016 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 62.21 μs | 0.111 μs | 0.099 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 44.84 μs | 0.292 μs | 0.273 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 46.99 μs | 0.285 μs | 0.223 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 49.74 μs | 0.203 μs | 0.190 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 90.85 μs | 0.154 μs | 0.129 μs |   42072 B |