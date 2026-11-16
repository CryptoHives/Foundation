| Description                                           | Mean      | Error    | StdDev   | Allocated |
|------------------------------------------------------ |----------:|---------:|---------:|----------:|
| Sign · ML-DSA-44 · CryptoHives                        | 163.37 μs | 1.003 μs | 0.837 μs |  90.85 KB |
| Sign · ML-DSA-44 · CryptoHives-Stateless              | 164.21 μs | 2.388 μs | 2.233 μs |  90.35 KB |
| Sign · ML-DSA-44 · BouncyCastle                       | 174.26 μs | 2.146 μs | 2.008 μs |  103.5 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-65 · CryptoHives-Stateless              | 264.93 μs | 3.108 μs | 2.907 μs | 135.57 KB |
| Sign · ML-DSA-65 · CryptoHives                        | 266.44 μs | 3.076 μs | 2.877 μs | 135.69 KB |
| Sign · ML-DSA-65 · BouncyCastle                       | 287.80 μs | 4.064 μs | 3.801 μs | 164.76 KB |
|                                                       |           |          |          |           |
| Sign · ML-DSA-87 · CryptoHives                        | 326.75 μs | 4.220 μs | 3.947 μs | 194.94 KB |
| Sign · ML-DSA-87 · CryptoHives-Stateless              | 326.81 μs | 4.698 μs | 4.395 μs | 194.65 KB |
| Sign · ML-DSA-87 · BouncyCastle                       | 354.04 μs | 5.187 μs | 4.852 μs | 234.97 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives-Stateless   | 162.29 μs | 1.436 μs | 1.344 μs |  90.69 KB |
| Sign (pre-hash) · ML-DSA-44 · CryptoHives             | 163.92 μs | 1.300 μs | 1.216 μs |  91.13 KB |
| Sign (pre-hash) · ML-DSA-44 · BouncyCastle            | 175.73 μs | 2.355 μs | 2.203 μs | 104.09 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives             | 264.93 μs | 3.013 μs | 2.818 μs | 135.56 KB |
| Sign (pre-hash) · ML-DSA-65 · CryptoHives-Stateless   | 265.35 μs | 3.499 μs | 2.731 μs | 136.35 KB |
| Sign (pre-hash) · ML-DSA-65 · BouncyCastle            | 289.38 μs | 5.135 μs | 4.803 μs | 167.46 KB |
|                                                       |           |          |          |           |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives-Stateless   | 326.53 μs | 3.917 μs | 3.664 μs | 195.34 KB |
| Sign (pre-hash) · ML-DSA-87 · CryptoHives             | 327.90 μs | 4.328 μs | 4.049 μs |  195.4 KB |
| Sign (pre-hash) · ML-DSA-87 · BouncyCastle            | 352.69 μs | 3.223 μs | 2.858 μs | 236.41 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-44 · CryptoHives                      |  45.12 μs | 0.150 μs | 0.141 μs |   49.3 KB |
| Verify · ML-DSA-44 · CryptoHives-Stateless            |  45.13 μs | 0.118 μs | 0.110 μs |   49.3 KB |
| Verify · ML-DSA-44 · BouncyCastle                     |  45.42 μs | 0.102 μs | 0.095 μs |  55.66 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-65 · CryptoHives                      |  72.57 μs | 0.070 μs | 0.062 μs |  79.54 KB |
| Verify · ML-DSA-65 · CryptoHives-Stateless            |  72.68 μs | 0.129 μs | 0.121 μs |  79.54 KB |
| Verify · ML-DSA-65 · BouncyCastle                     |  73.71 μs | 0.111 μs | 0.099 μs |  92.81 KB |
|                                                       |           |          |          |           |
| Verify · ML-DSA-87 · CryptoHives-Stateless            | 118.88 μs | 0.221 μs | 0.207 μs | 128.96 KB |
| Verify · ML-DSA-87 · CryptoHives                      | 119.10 μs | 0.201 μs | 0.179 μs | 128.96 KB |
| Verify · ML-DSA-87 · BouncyCastle                     | 121.36 μs | 0.265 μs | 0.248 μs | 154.83 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives           |  44.12 μs | 0.090 μs | 0.084 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · CryptoHives-Stateless |  44.20 μs | 0.094 μs | 0.088 μs |  49.63 KB |
| Verify (pre-hash) · ML-DSA-44 · BouncyCastle          |  46.68 μs | 0.126 μs | 0.118 μs |  56.07 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives           |  71.85 μs | 0.127 μs | 0.119 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · CryptoHives-Stateless |  71.92 μs | 0.154 μs | 0.136 μs |  79.87 KB |
| Verify (pre-hash) · ML-DSA-65 · BouncyCastle          |  74.80 μs | 0.176 μs | 0.165 μs |  93.23 KB |
|                                                       |           |          |          |           |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives           | 117.93 μs | 0.288 μs | 0.270 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · CryptoHives-Stateless | 117.97 μs | 0.251 μs | 0.235 μs | 129.29 KB |
| Verify (pre-hash) · ML-DSA-87 · BouncyCastle          | 122.44 μs | 0.382 μs | 0.357 μs | 155.24 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-44 · CryptoHives-Stateless  |  45.15 μs | 0.070 μs | 0.066 μs |   49.3 KB |
| Verify (invalid) · ML-DSA-44 · BouncyCastle           |  45.17 μs | 0.095 μs | 0.089 μs |  55.66 KB |
| Verify (invalid) · ML-DSA-44 · CryptoHives            |  45.19 μs | 0.120 μs | 0.113 μs |   49.3 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-65 · CryptoHives-Stateless  |  72.66 μs | 0.164 μs | 0.153 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · CryptoHives            |  72.78 μs | 0.157 μs | 0.147 μs |  79.54 KB |
| Verify (invalid) · ML-DSA-65 · BouncyCastle           |  74.17 μs | 0.165 μs | 0.155 μs |  92.81 KB |
|                                                       |           |          |          |           |
| Verify (invalid) · ML-DSA-87 · CryptoHives-Stateless  | 119.08 μs | 0.194 μs | 0.181 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · CryptoHives            | 119.09 μs | 0.145 μs | 0.136 μs | 128.96 KB |
| Verify (invalid) · ML-DSA-87 · BouncyCastle           | 121.33 μs | 0.203 μs | 0.190 μs | 154.83 KB |