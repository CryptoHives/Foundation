| Description                                                  | Mean     | Error    | StdDev   | Allocated |
|------------------------------------------------------------- |---------:|---------:|---------:|----------:|
| Encapsulate · ML-KEM-512 · CryptoHives                       | 14.05 μs | 0.047 μs | 0.044 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             | 14.22 μs | 0.046 μs | 0.043 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      | 16.29 μs | 0.022 μs | 0.019 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          | 29.65 μs | 0.117 μs | 0.109 μs |   15560 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-768 · CryptoHives                       | 22.24 μs | 0.083 μs | 0.077 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             | 22.52 μs | 0.077 μs | 0.072 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      | 26.00 μs | 0.049 μs | 0.046 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          | 47.10 μs | 0.206 μs | 0.193 μs |   25120 B |
|                                                              |          |          |          |           |
| Encapsulate · ML-KEM-1024 · CryptoHives                      | 32.53 μs | 0.133 μs | 0.124 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 32.90 μs | 0.138 μs | 0.129 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     | 38.49 μs | 0.113 μs | 0.105 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         | 70.40 μs | 0.335 μs | 0.313 μs |   37248 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-512 · CryptoHives                       | 20.10 μs | 0.074 μs | 0.069 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             | 21.17 μs | 0.057 μs | 0.053 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      | 22.54 μs | 0.071 μs | 0.066 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          | 40.14 μs | 0.111 μs | 0.104 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-768 · CryptoHives                       | 30.25 μs | 0.085 μs | 0.079 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             | 31.81 μs | 0.068 μs | 0.064 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      | 34.42 μs | 0.115 μs | 0.107 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          | 61.84 μs | 0.212 μs | 0.198 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate · ML-KEM-1024 · CryptoHives                      | 42.92 μs | 0.112 μs | 0.104 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            | 44.85 μs | 0.157 μs | 0.147 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     | 49.60 μs | 0.196 μs | 0.183 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 91.35 μs | 0.238 μs | 0.223 μs |   42072 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            | 20.13 μs | 0.058 μs | 0.054 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  | 21.22 μs | 0.028 μs | 0.026 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           | 22.50 μs | 0.064 μs | 0.060 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               | 40.23 μs | 0.149 μs | 0.139 μs |   17952 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            | 30.26 μs | 0.077 μs | 0.072 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  | 31.83 μs | 0.132 μs | 0.124 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           | 34.66 μs | 0.089 μs | 0.083 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               | 62.20 μs | 0.150 μs | 0.125 μs |   28408 B |
|                                                              |          |          |          |           |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           | 42.95 μs | 0.141 μs | 0.132 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless | 44.89 μs | 0.156 μs | 0.146 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          | 49.66 μs | 0.162 μs | 0.151 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 91.07 μs | 0.237 μs | 0.222 μs |   42072 B |