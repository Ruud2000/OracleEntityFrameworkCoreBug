# Start with an image of the Oracle 21c XE database.
# We use the slim version which is the smallest image and has a lot of extra features remove.
# This vsion is sufficient since we only want a basic Oracle database.
FROM gvenzl/oracle-xe:21.3.0-slim

# Copy the SQL scripts to be executed during initialization of the database to the designated folder.
# See section 'Initialization scripts' on https://hub.docker.com/r/gvenzl/oracle-xe for more info.
COPY ./1-database-schema.sql /container-entrypoint-initdb.d
COPY ./2-test-data.sql /container-entrypoint-initdb.d

# Use same entrypoint as used by the Dockerfile that is used to create our starting image.
# See https://github.com/gvenzl/oci-oracle-xe/blob/main/Dockerfile.2130
ENTRYPOINT ["container-entrypoint.sh"]
