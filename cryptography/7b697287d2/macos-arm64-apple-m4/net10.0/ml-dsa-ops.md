| Description                                           | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------ |----------:|---------:|---------:|----------:|
| Sign · ML-DSA-44 · CryptoHives                        | 161.01 μs | 1.582 μs | 1.480 μs |  90.75 KB |
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 162.49 μs | 1.101 μs | 1.030 μs |  90.17 KB |
| Sign · ML-DSA-44 · BouncyCastle                       | 171.38 μs | 2.166 μs | 2.026 μs | 103.48 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 263.13 μs | 4.538 μs | 4.245 μs | 135.49 KB |
| Sign · ML-DSA-65 · CryptoHives                        | 263.43 μs | 4.733 μs | 4.195 μs | 136.18 KB |
| Sign · ML-DSA-65 · BouncyCastle                       | 283.01 μs | 5.496 μs | 5.881 μs | 166.29 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 324.66 μs | 3.169 μs | 2.964 μs | 195.02 KB |
| Sign · ML-DSA-87 · CryptoHives                        | 325.28 μs | 4.521 μs | 4.229 μs | 195.16 KB |
| Sign · ML-DSA-87 · BouncyCastle                       | 355.61 μs | 5.539 μs | 5.181 μs | 236.55 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 161.12 μs | 1.943 μs | 1.818 μs |  90.65 KB |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 161.44 μs | 2.081 μs | 1.946 μs |  90.92 KB |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 173.12 μs | 1.384 μs | 1.294 μs | 103.71 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 259.09 μs | 4.104 μs | 3.839 μs | 135.32 KB |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 260.43 μs | 2.969 μs | 2.778 μs | 136.08 KB |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 282.18 μs | 4.490 μs | 3.981 μs | 168.56 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 325.33 μs | 3.515 μs | 3.288 μs | 195.07 KB |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 325.40 μs | 5.102 μs | 4.772 μs | 195.78 KB |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 352.44 μs | 4.720 μs | 4.415 μs | 237.75 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  44.71 μs | 0.108 μs | 0.101 μs |   49.3 KB |
| Verify · ML-DSA-44 · CryptoHives                      |  44.72 μs | 0.153 μs | 0.143 μs |   49.3 KB |
| Verify · ML-DSA-44 · BouncyCastle                     |  44.94 μs | 0.109 μs | 0.102 μs |  55.66 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-65 · CryptoHives                      |  72.05 μs | 0.190 μs | 0.178 μs |  79.54 KB |
| Verify · ML-DSA-65 · CryptoHives-Stateless            |  72.07 μs | 0.122 μs | 0.102 μs |  79.54 KB |
| Verify · ML-DSA-65 · BouncyCastle                     |  72.75 μs | 0.201 μs | 0.188 μs |  92.81 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 117.72 μs | 0.359 μs | 0.336 μs | 128.96 KB |
| Verify · ML-DSA-87 · CryptoHives                      | 117.93 μs | 0.332 μs | 0.311 μs | 128.96 KB |
| Verify · ML-DSA-87 · BouncyCastle                     | 120.19 μs | 0.233 μs | 0.194 μs | 154.83 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  43.80 μs | 0.125 μs | 0.097 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  43.85 μs | 0.218 μs | 0.170 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  46.69 μs | 0.097 μs | 0.091 μs |  56.07 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           |  71.26 μs | 0.183 μs | 0.163 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless |  71.27 μs | 0.166 μs | 0.147 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          |  75.04 μs | 0.396 μs | 0.370 μs |  93.23 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 117.27 μs | 0.509 μs | 0.451 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 117.32 μs | 0.423 μs | 0.353 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 122.44 μs | 0.199 μs | 0.186 μs | 155.24 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  44.68 μs | 0.115 μs | 0.107 μs |   49.3 KB |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  44.73 μs | 0.150 μs | 0.141 μs |   49.3 KB |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  44.96 μs | 0.034 μs | 0.029 μs |  55.66 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-65 · CryptoHives            |  71.78 μs | 0.133 μs | 0.117 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  |  71.92 μs | 0.085 μs | 0.075 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           |  72.72 μs | 0.037 μs | 0.029 μs |  92.81 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 117.48 μs | 0.079 μs | 0.066 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 117.66 μs | 0.059 μs | 0.046 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 120.26 μs | 0.154 μs | 0.137 μs | 154.83 KB |