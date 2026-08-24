| Description                                                  | Mean       | Error     | StdDev    | Allocated |
|------------------------------------------------------------- |-----------:|----------:|----------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |   9.552 μs | 0.0572 μs | 0.0477 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  21.849 μs | 0.0400 μs | 0.0313 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  21.942 μs | 0.0676 μs | 0.0599 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  25.775 μs | 0.0455 μs | 0.0355 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  36.165 μs | 0.1283 μs | 0.1200 μs |   15560 B |
|                                                              |            |           |           |           |
| Encapsulate · ML-KEM-768 · OS                                |  12.828 μs | 0.0143 μs | 0.0126 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  34.510 μs | 0.0509 μs | 0.0476 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  34.882 μs | 0.0741 μs | 0.0619 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  41.549 μs | 0.1297 μs | 0.1214 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  57.152 μs | 0.2113 μs | 0.1764 μs |   25120 B |
|                                                              |            |           |           |           |
| Encapsulate · ML-KEM-1024 · OS                               |  17.263 μs | 0.0214 μs | 0.0189 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  50.540 μs | 0.0725 μs | 0.0605 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  51.035 μs | 0.1027 μs | 0.0960 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  60.344 μs | 0.1049 μs | 0.0876 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  84.197 μs | 0.2021 μs | 0.1791 μs |   37248 B |
|                                                              |            |           |           |           |
| Decapsulate · ML-KEM-512 · OS                                |  14.463 μs | 0.0238 μs | 0.0222 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  30.709 μs | 0.0319 μs | 0.0249 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  32.293 μs | 0.1421 μs | 0.1187 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  34.689 μs | 0.0891 μs | 0.0834 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  52.071 μs | 0.1866 μs | 0.1746 μs |   17952 B |
|                                                              |            |           |           |           |
| Decapsulate · ML-KEM-768 · OS                                |  19.552 μs | 0.0483 μs | 0.0403 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  46.810 μs | 0.1668 μs | 0.1560 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  48.682 μs | 0.0533 μs | 0.0445 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  52.663 μs | 0.1286 μs | 0.1140 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  79.259 μs | 0.1344 μs | 0.1122 μs |   28408 B |
|                                                              |            |           |           |           |
| Decapsulate · ML-KEM-1024 · OS                               |  25.724 μs | 0.0536 μs | 0.0448 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  66.181 μs | 0.1699 μs | 0.1506 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  68.686 μs | 0.1061 μs | 0.0886 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  75.222 μs | 0.1454 μs | 0.1214 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 112.186 μs | 0.2250 μs | 0.1879 μs |   42072 B |
|                                                              |            |           |           |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  14.469 μs | 0.0232 μs | 0.0206 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  30.787 μs | 0.0688 μs | 0.0644 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  32.211 μs | 0.0545 μs | 0.0455 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  34.286 μs | 0.0663 μs | 0.0518 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  52.316 μs | 0.1971 μs | 0.1844 μs |   17952 B |
|                                                              |            |           |           |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  19.599 μs | 0.1322 μs | 0.1104 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  47.068 μs | 0.0682 μs | 0.0569 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  48.710 μs | 0.1529 μs | 0.1355 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  52.529 μs | 0.1334 μs | 0.1248 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  79.318 μs | 0.1792 μs | 0.1399 μs |   28408 B |
|                                                              |            |           |           |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  25.788 μs | 0.0514 μs | 0.0481 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  66.657 μs | 0.0797 μs | 0.0622 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  68.806 μs | 0.1361 μs | 0.1137 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  75.530 μs | 0.3758 μs | 0.3138 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 111.780 μs | 0.3336 μs | 0.3121 μs |   42072 B |