| Description                                                  | Mean     | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |---------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · CryptoHives                       | 14.82 μs | 0.008 μs | 0.008 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             | 14.96 μs | 0.010 μs | 0.009 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      | 16.49 μs | 0.015 μs | 0.014 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          | 30.08 μs | 0.029 μs | 0.025 μs |   15560 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-768 · CryptoHives                       | 23.48 μs | 0.024 μs | 0.022 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             | 23.74 μs | 0.018 μs | 0.016 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      | 26.29 μs | 0.018 μs | 0.016 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 47.25 μs | 0.046 μs | 0.041 μs |   25120 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-1024 · CryptoHives                      | 34.29 μs | 0.035 μs | 0.033 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 34.94 μs | 0.027 μs | 0.024 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 38.77 μs | 0.026 μs | 0.025 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 71.52 μs | 0.125 μs | 0.111 μs |   37248 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-512 · CryptoHives                       | 21.22 μs | 0.018 μs | 0.017 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             | 22.23 μs | 0.026 μs | 0.025 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      | 22.79 μs | 0.011 μs | 0.010 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 40.96 μs | 0.106 μs | 0.100 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-768 · CryptoHives                       | 32.04 μs | 0.055 μs | 0.052 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             | 33.54 μs | 0.098 μs | 0.086 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      | 35.19 μs | 0.111 μs | 0.098 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 63.40 μs | 0.116 μs | 0.103 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 45.55 μs | 0.095 μs | 0.084 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 47.66 μs | 0.100 μs | 0.094 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 50.32 μs | 0.112 μs | 0.104 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 91.71 μs | 0.314 μs | 0.278 μs |   42072 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            | 21.22 μs | 0.018 μs | 0.016 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  | 22.30 μs | 0.022 μs | 0.021 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           | 22.78 μs | 0.014 μs | 0.013 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 40.77 μs | 0.168 μs | 0.157 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            | 31.45 μs | 0.027 μs | 0.024 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  | 32.93 μs | 0.022 μs | 0.019 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           | 35.07 μs | 0.018 μs | 0.017 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 62.36 μs | 0.080 μs | 0.067 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 44.75 μs | 0.053 μs | 0.050 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 46.79 μs | 0.027 μs | 0.024 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 49.48 μs | 0.028 μs | 0.025 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 90.74 μs | 0.178 μs | 0.166 μs |   42072 B |