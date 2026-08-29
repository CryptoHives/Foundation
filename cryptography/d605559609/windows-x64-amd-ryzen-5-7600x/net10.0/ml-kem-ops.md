| Description                                                  | Mean       | Error     | StdDev    | Allocated |
|------------------------------------------------------------- |-----------:|----------:|----------:|----------:|
| Encapsulate · ML-KEM-512 · OS                                |   9.636 μs | 0.1043 μs | 0.0976 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives                       |  21.994 μs | 0.1333 μs | 0.1247 μs |         - |
| Encapsulate · ML-KEM-512 · CryptoHives-Stateless             |  22.258 μs | 0.0518 μs | 0.0432 μs |         - |
| Encapsulate · ML-KEM-512 · BouncyCastle                      |  26.105 μs | 0.1113 μs | 0.1041 μs |   12952 B |
| Encapsulate · ML-KEM-512 · KyberNET                          |  36.303 μs | 0.2729 μs | 0.2419 μs |   15560 B |
|                                                              |            |           |           |           |
| Encapsulate · ML-KEM-768 · OS                                |  12.883 μs | 0.0370 μs | 0.0289 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives                       |  34.859 μs | 0.0908 μs | 0.0805 μs |         - |
| Encapsulate · ML-KEM-768 · CryptoHives-Stateless             |  35.240 μs | 0.1338 μs | 0.1252 μs |         - |
| Encapsulate · ML-KEM-768 · BouncyCastle                      |  41.352 μs | 0.1257 μs | 0.1176 μs |   18680 B |
| Encapsulate · ML-KEM-768 · KyberNET                          |  56.821 μs | 0.2539 μs | 0.2375 μs |   25120 B |
|                                                              |            |           |           |           |
| Encapsulate · ML-KEM-1024 · OS                               |  17.299 μs | 0.0421 μs | 0.0352 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives                      |  50.955 μs | 0.0927 μs | 0.0774 μs |         - |
| Encapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  51.430 μs | 0.1906 μs | 0.1592 μs |         - |
| Encapsulate · ML-KEM-1024 · BouncyCastle                     |  60.545 μs | 0.2656 μs | 0.2485 μs |   25544 B |
| Encapsulate · ML-KEM-1024 · KyberNET                         |  83.406 μs | 0.2741 μs | 0.2289 μs |   37248 B |
|                                                              |            |           |           |           |
| Decapsulate · ML-KEM-512 · OS                                |  14.599 μs | 0.0431 μs | 0.0337 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives                       |  31.396 μs | 0.0642 μs | 0.0536 μs |         - |
| Decapsulate · ML-KEM-512 · CryptoHives-Stateless             |  32.875 μs | 0.1215 μs | 0.1015 μs |         - |
| Decapsulate · ML-KEM-512 · BouncyCastle                      |  34.851 μs | 0.1867 μs | 0.1747 μs |   16976 B |
| Decapsulate · ML-KEM-512 · KyberNET                          |  52.217 μs | 0.2432 μs | 0.2156 μs |   17952 B |
|                                                              |            |           |           |           |
| Decapsulate · ML-KEM-768 · OS                                |  19.668 μs | 0.0536 μs | 0.0475 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives                       |  46.856 μs | 0.1225 μs | 0.1023 μs |         - |
| Decapsulate · ML-KEM-768 · CryptoHives-Stateless             |  48.873 μs | 0.2432 μs | 0.2031 μs |         - |
| Decapsulate · ML-KEM-768 · BouncyCastle                      |  53.110 μs | 0.7513 μs | 0.5866 μs |   23840 B |
| Decapsulate · ML-KEM-768 · KyberNET                          |  80.906 μs | 0.2733 μs | 0.2423 μs |   28408 B |
|                                                              |            |           |           |           |
| Decapsulate · ML-KEM-1024 · OS                               |  26.065 μs | 0.0608 μs | 0.0539 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives                      |  67.555 μs | 0.1462 μs | 0.1142 μs |         - |
| Decapsulate · ML-KEM-1024 · CryptoHives-Stateless            |  70.010 μs | 0.3541 μs | 0.3312 μs |         - |
| Decapsulate · ML-KEM-1024 · BouncyCastle                     |  76.003 μs | 0.3698 μs | 0.3278 μs |   31840 B |
| Decapsulate · ML-KEM-1024 · KyberNET                         | 114.954 μs | 0.5308 μs | 0.4965 μs |   42072 B |
|                                                              |            |           |           |           |
| Decapsulate (rejected) · ML-KEM-512 · OS                     |  14.627 μs | 0.0961 μs | 0.0802 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives            |  31.208 μs | 0.0425 μs | 0.0355 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · CryptoHives-Stateless  |  32.857 μs | 0.1294 μs | 0.1010 μs |         - |
| Decapsulate (rejected) · ML-KEM-512 · BouncyCastle           |  35.072 μs | 0.1808 μs | 0.1411 μs |   16976 B |
| Decapsulate (rejected) · ML-KEM-512 · KyberNET               |  52.001 μs | 0.0842 μs | 0.0658 μs |   17952 B |
|                                                              |            |           |           |           |
| Decapsulate (rejected) · ML-KEM-768 · OS                     |  19.726 μs | 0.0329 μs | 0.0257 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives            |  47.688 μs | 0.1631 μs | 0.1526 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · CryptoHives-Stateless  |  49.222 μs | 0.1434 μs | 0.1271 μs |         - |
| Decapsulate (rejected) · ML-KEM-768 · BouncyCastle           |  53.534 μs | 1.0162 μs | 0.9981 μs |   23840 B |
| Decapsulate (rejected) · ML-KEM-768 · KyberNET               |  79.907 μs | 0.2662 μs | 0.2360 μs |   28408 B |
|                                                              |            |           |           |           |
| Decapsulate (rejected) · ML-KEM-1024 · OS                    |  25.991 μs | 0.0577 μs | 0.0482 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives           |  67.687 μs | 0.4610 μs | 0.3599 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · CryptoHives-Stateless |  69.364 μs | 0.2795 μs | 0.2614 μs |         - |
| Decapsulate (rejected) · ML-KEM-1024 · BouncyCastle          |  76.661 μs | 0.2949 μs | 0.2614 μs |   31840 B |
| Decapsulate (rejected) · ML-KEM-1024 · KyberNET              | 113.327 μs | 0.6161 μs | 0.5763 μs |   42072 B |