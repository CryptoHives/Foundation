| Description                                                  | Mean     | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |---------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · CryptoHives                       | 14.19 μs | 0.036 μs | 0.034 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             | 14.39 μs | 0.046 μs | 0.043 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      | 16.59 μs | 0.045 μs | 0.042 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          | 30.06 μs | 0.124 μs | 0.116 μs |   15560 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-768 · CryptoHives                       | 22.51 μs | 0.064 μs | 0.060 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             | 22.74 μs | 0.053 μs | 0.050 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      | 26.75 μs | 0.081 μs | 0.075 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 47.79 μs | 0.160 μs | 0.149 μs |   25120 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-1024 · CryptoHives                      | 32.89 μs | 0.099 μs | 0.093 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 33.29 μs | 0.084 μs | 0.078 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 39.60 μs | 0.209 μs | 0.196 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 71.82 μs | 0.602 μs | 0.503 μs |   37248 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-512 · CryptoHives                       | 20.49 μs | 0.350 μs | 0.310 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             | 21.38 μs | 0.048 μs | 0.045 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      | 23.09 μs | 0.089 μs | 0.075 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 40.86 μs | 0.184 μs | 0.163 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-768 · CryptoHives                       | 30.70 μs | 0.171 μs | 0.152 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             | 32.10 μs | 0.082 μs | 0.076 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      | 35.17 μs | 0.192 μs | 0.179 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 63.08 μs | 0.141 μs | 0.125 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 43.51 μs | 0.435 μs | 0.339 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 45.49 μs | 0.743 μs | 0.580 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 50.86 μs | 0.207 μs | 0.173 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 91.80 μs | 0.584 μs | 0.488 μs |   42072 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            | 20.47 μs | 0.339 μs | 0.283 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  | 21.45 μs | 0.165 μs | 0.147 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           | 22.90 μs | 0.135 μs | 0.113 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 40.54 μs | 0.119 μs | 0.106 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            | 30.88 μs | 0.421 μs | 0.373 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  | 32.01 μs | 0.072 μs | 0.057 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           | 35.11 μs | 0.074 μs | 0.062 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 63.30 μs | 0.673 μs | 0.597 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 43.36 μs | 0.218 μs | 0.182 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 45.57 μs | 0.591 μs | 0.524 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 50.18 μs | 0.457 μs | 0.405 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 91.55 μs | 0.408 μs | 0.362 μs |   42072 B |