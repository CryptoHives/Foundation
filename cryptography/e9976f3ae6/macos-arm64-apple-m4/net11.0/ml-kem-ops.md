| Description                                                  | Mean     | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |---------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · CryptoHives                       | 14.26 μs | 0.045 μs | 0.042 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             | 14.38 μs | 0.044 μs | 0.041 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      | 16.00 μs | 0.059 μs | 0.052 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          | 29.09 μs | 0.109 μs | 0.102 μs |   15560 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-768 · CryptoHives                       | 22.75 μs | 0.057 μs | 0.054 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             | 22.96 μs | 0.055 μs | 0.051 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      | 25.66 μs | 0.150 μs | 0.140 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 45.85 μs | 0.181 μs | 0.169 μs |   25120 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 33.75 μs | 0.072 μs | 0.067 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      | 33.77 μs | 0.108 μs | 0.101 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 38.03 μs | 0.190 μs | 0.178 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 68.24 μs | 0.462 μs | 0.432 μs |   37248 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-512 · CryptoHives                       | 20.30 μs | 0.077 μs | 0.072 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             | 21.40 μs | 0.057 μs | 0.053 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      | 22.30 μs | 0.081 μs | 0.076 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 38.89 μs | 0.063 μs | 0.059 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-768 · CryptoHives                       | 30.92 μs | 0.021 μs | 0.020 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             | 32.17 μs | 0.084 μs | 0.078 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      | 34.28 μs | 0.116 μs | 0.109 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 60.02 μs | 0.074 μs | 0.069 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 43.56 μs | 0.024 μs | 0.022 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 45.48 μs | 0.054 μs | 0.051 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 49.15 μs | 0.221 μs | 0.207 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 87.84 μs | 0.117 μs | 0.109 μs |   42072 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            | 20.26 μs | 0.031 μs | 0.029 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  | 21.33 μs | 0.077 μs | 0.072 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           | 22.47 μs | 0.061 μs | 0.057 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 39.17 μs | 0.097 μs | 0.090 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            | 30.64 μs | 0.032 μs | 0.030 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  | 32.14 μs | 0.031 μs | 0.029 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           | 34.12 μs | 0.093 μs | 0.087 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 59.94 μs | 0.116 μs | 0.109 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 43.57 μs | 0.040 μs | 0.037 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 45.66 μs | 0.042 μs | 0.039 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 49.28 μs | 0.195 μs | 0.182 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 87.74 μs | 0.125 μs | 0.117 μs |   42072 B |