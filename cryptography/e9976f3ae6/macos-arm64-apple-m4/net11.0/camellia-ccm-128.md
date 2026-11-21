| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.567 μs | 0.0033 μs | 0.0027 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.155 μs | 0.0091 μs | 0.0085 μs |    2152 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.520 μs | 0.0047 μs | 0.0044 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.103 μs | 0.0108 μs | 0.0101 μs |    2000 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    10.045 μs | 0.0591 μs | 0.0553 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    12.098 μs | 0.0220 μs | 0.0195 μs |    7528 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    10.076 μs | 0.0497 μs | 0.0464 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    11.988 μs | 0.0335 μs | 0.0313 μs |    6480 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    76.801 μs | 0.3226 μs | 0.3018 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |    92.470 μs | 0.2497 μs | 0.2336 μs |   50536 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    76.650 μs | 0.4201 μs | 0.3929 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |    91.970 μs | 0.2607 μs | 0.2177 μs |   42320 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,229.895 μs | 7.2717 μs | 6.8020 μs |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,488.916 μs | 4.6498 μs | 4.1220 μs |  787842 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,222.491 μs | 5.2915 μs | 4.9496 μs |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,462.901 μs | 3.5011 μs | 3.2749 μs |  656720 B |